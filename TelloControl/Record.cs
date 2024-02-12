using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelloControl
{
    public partial class Record : Form
    {
        static string timestamp = DateTime.Now.ToString("MMdd_HHmmss");
        static string baseFolder = "Logs";
        string csvFilePath = Path.Combine(baseFolder, $"TelloFlightLog_{timestamp}.csv"); // Log file path
        string txtFilePath = Path.Combine(baseFolder, $"TelloFlightLog_{timestamp}.txt"); // Log file path
        string droneIP = "192.168.10.1"; // Tello IP
        int commandPort = 8889; // Command port
        int telemetryPort = 8890; // Telemetry data port

        private bool Recording = false;

        public Record()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var result = Initiate();
        }

        private void btnTakeOff_Click(object sender, EventArgs e)
        {
            RecordStop();
            using (var commandClient = new UdpClient())
            {
                commandClient.Connect(droneIP, commandPort);
                var result = SendCommandAsync(TelloCommand.takeoff.ToString(), commandClient);
            }
        }

        private void btnLand_Click(object sender, EventArgs e)
        {
            RecordStop();
            using (var commandClient = new UdpClient())
            {
                commandClient.Connect(droneIP, commandPort);
                var result = SendCommandAsync(TelloCommand.land.ToString(), commandClient);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            txtCommand.Text = "";
            RecordStart("all", true);
        }

        private async Task RecordStart(string? suffix = null, bool newFile = false)
        {
            Recording = !newFile;
            if (!Recording)
            {
                timestamp = DateTime.Now.ToString("MMdd_HHmmss");
                csvFilePath = Path.Combine(baseFolder, $"{txtPilot.Text} {timestamp} {txtCommand.Text} {suffix}.csv").Trim().Replace(" ", "_");
                txtFilePath = Path.Combine(baseFolder, $"{txtPilot.Text} {timestamp} {txtCommand.Text} {suffix}.txt").Trim().Replace(" ", "_");
                Recording = true;
            }
            await RecordFlightLogAsync(telemetryPort, csvFilePath);
        }

        private async Task RecordStop() => Recording = false;

        private void btnStop_Click(object sender, EventArgs e)
        {
            RecordStop();
        }

        private async Task Initiate()
        {
            using (var commandClient = new UdpClient())
            {
                commandClient.Connect(droneIP, commandPort);
                await SendCommandAsync(TelloCommand.command.ToString(), commandClient);
            }
        }

        async Task SendCommandAsync(string command, UdpClient client)
        {
            Log(command);
            var commandBytes = Encoding.ASCII.GetBytes(command);
            await client.SendAsync(commandBytes, commandBytes.Length);
            var result = await client.ReceiveAsync();
            Log(Encoding.ASCII.GetString(result.Buffer));
        }

        async Task RecordFlightLogAsync(int telemetryPort, string filePath)
        {
            using (var telemetryClient = new UdpClient(telemetryPort))
            {
                try
                {
                    using (var logFile = new StreamWriter(filePath))
                    {
                        Log("Recording start to file : " + filePath);
                        logFile.WriteLine("Pilot,timestamp_ms,command,pitch,roll,yaw,vgx,vgy,vgz,templ,temph,tof,h,bat,baro,time,agx,agy,agz");
                        var startTime = DateTime.Now;

                        while (Recording)
                        {
                            string telemetryData = await ReceiveTelemetryDataAsync(telemetryClient).WaitAsync(TimeSpan.FromSeconds(15));
                            telemetryData = telemetryData.TrimEnd('\n', '\r');
                            var elapsedTime = (DateTime.Now - startTime).TotalMilliseconds;
                            var csvLine = ConvertToCsvLine(telemetryData, startTime);
                            lblTemp.Text = $"{csvLine[6]}~{csvLine[7]} ℃";
                            lblBattery.Text = $"{csvLine[10]} %";
                            lblH.Text = $"{csvLine[9]} h";
                            lblTime.Text = $"{csvLine[12]} t";
                            await logFile.WriteLineAsync(string.Join(",", txtPilot.Text, elapsedTime.ToString(), txtCommand.Text, string.Join(",", csvLine)));
                        }
                        Log("Recording complete to file : {0}", filePath);
                    }
                    Log("UDP client closing {0}", telemetryClient.Client.RemoteEndPoint?.ToString());
                }
                catch (Exception e)
                {
                    Log("Receiving Telemetry Error: " + e.Message);
                }
            }
        }

        async Task<string> ReceiveTelemetryDataAsync(UdpClient client)
        {
            var result = await client.ReceiveAsync();
            var ascii = Encoding.ASCII.GetString(result.Buffer);
            switch (ascii)
            {
                case "ok":
                case "error":
                case "error Not joystick":
                    Log(ascii);
                    break;
            }
            return ascii;
        }

        string[] ConvertToCsvLine(string telemetryData, DateTime startTime)
        {
            var keyValuePairs = telemetryData.TrimEnd(';').Split(';');
            var values = keyValuePairs.Where(x => x.Contains(':')).Select(kvp => kvp.Split(':')[1]);
            return values.ToArray();
        }

        #region Logs

        public async Task Log(string text, params string[] @params)
        {
            var sb = new StringBuilder();
            var prefix = $"{DateTime.Now:yy/MM/dd HH:mm:ss.fff} | ";
            sb.Append(prefix);
            sb.Append(text);
            foreach (var s in @params)
            {
                sb.AppendLine(s);
            }
            var msg = sb.ToString();
            txtLog.AppendText(msg + Environment.NewLine);
            await FileWriteAsync(msg);
            Task.Delay(100);
        }

        public async Task FileWriteAsync(string messaage, bool append = true)
        {
            using (FileStream stream = new FileStream(txtFilePath, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    await sw.WriteLineAsync(messaage);
                }
            }
        }

        #endregion

        private int GetParsedDistanceAngle(bool negate = false)
        {
            var x = Math.Min(100, Convert.ToInt32(txtDistanceAngle.Text));
            return negate ? x * -1 : x;
        }

        private async Task IssueBtnCommandAndLog(TelloCommand command)
        {
            var rcCompatible = true;
            if (new[] { TelloCommand.emergency, TelloCommand.command, TelloCommand.takeoff, TelloCommand.land }.Contains(command))
            {
                txtCommand.Text = command.ToString();
                rcCompatible = false;
            }
            else
            {
                var abcd = new RC(TelloCommand.rc);
                if (!chkUseRC.Checked)
                    rcCompatible = false;
                else
                {
                    switch (command)
                    {
                        case TelloCommand.left:
                            abcd.a = GetParsedDistanceAngle(true);
                            break;
                        case TelloCommand.right:
                            abcd.a = GetParsedDistanceAngle();
                            break;
                        case TelloCommand.up:
                            abcd.c = GetParsedDistanceAngle();
                            break;
                        case TelloCommand.down:
                            abcd.c = GetParsedDistanceAngle(true);
                            break;
                        case TelloCommand.forward:
                            abcd.b = GetParsedDistanceAngle();
                            break;
                        case TelloCommand.back:
                            abcd.b = GetParsedDistanceAngle(true);
                            break;
                        case TelloCommand.cw:
                            abcd.d = GetParsedDistanceAngle();
                            break;
                        case TelloCommand.ccw:
                            abcd.d = GetParsedDistanceAngle(true);
                            break;
                        case TelloCommand.hover:
                            break;
                        default:
                            Log("Not rc compatible command: {0}", command.ToString());
                            rcCompatible = false;
                            break;
                    }
                }

                txtCommand.Text = rcCompatible ? abcd.ToString() : $"{command} {txtDistanceAngle.Text}";
            }

            if (chkRecordStart.Checked) RecordStart(rcCompatible ? command.ToString() : "", true);

            using (var commandClient = new UdpClient())
            {
                commandClient.Connect(droneIP, commandPort);
                await SendCommandAsync(txtCommand.Text, commandClient);
            }
        }

        private async void btnLeft_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.left);
        }

        private async void btnRight_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.right);
        }

        private async void btnForward_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.forward);
        }

        private async void btnBackward_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.back);

        }

        private async void btnUp_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.up);

        }

        private async void btnDown_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.down);

        }

        private async void btnCCW_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.ccw);

        }

        private async void btnCW_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.cw);
        }

        private async void btnEmergency_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.emergency);
        }

        private async void btnHover_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog(TelloCommand.hover);
        }
    }

    public enum TelloCommand
    {
        emergency,
        command,
        takeoff,
        land,
        left,
        right,
        up,
        down,
        forward,
        back,
        cw,
        ccw,
        rc,
        hover
    }

    public class RC
    {
        private readonly TelloCommand _command;

        public RC(TelloCommand command)
        {
            _command = command;
        }

        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int d { get; set; }

        public override string ToString()
        {
            return $"{_command} {a} {b} {c} {d}".Trim();
        }
    }
}
