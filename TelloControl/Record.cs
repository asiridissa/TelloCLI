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
        string csvFilePath = $"TelloFlightLog_{timestamp}.csv"; // Log file path
        string txtFilePath = $"TelloFlightLog_{timestamp}.txt"; // Log file path
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
            Recording = false;
            using (var commandClient = new UdpClient())
            {
                commandClient.Connect(droneIP, commandPort);
                var result = SendCommandAsync("takeoff", commandClient);
            }
        }

        private void btnLand_Click(object sender, EventArgs e)
        {
            Recording = false;
            using (var commandClient = new UdpClient())
            {
                commandClient.Connect(droneIP, commandPort);
                var result = SendCommandAsync("land", commandClient);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            timestamp = DateTime.Now.ToString("MMdd_HHmmss");
            csvFilePath = $"{txtPilot.Text}_{timestamp}_{txtCommand.Text}.csv";
            txtFilePath = $"{txtPilot.Text}_{timestamp}_{txtCommand.Text}.txt";
            Recording = true;
            var result = RecordFlightLogAsync(telemetryPort, csvFilePath);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Recording = false;
        }

        private async Task Initiate()
        {
            using (var commandClient = new UdpClient())
            {
                commandClient.Connect(droneIP, commandPort);
                await SendCommandAsync("command", commandClient);
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
            try
            {
                using (var telemetryClient = new UdpClient(telemetryPort))
                {
                    using (var logFile = new StreamWriter(filePath))
                    {
                        txtLog.AppendText("Writing start to file : " + filePath + Environment.NewLine);
                        logFile.WriteLine("timestamp_ms,pitch,roll,yaw,vgx,vgy,vgz,templ,temph,tof,h,bat,baro,time,agx,agy,agz");
                        var startTime = DateTime.Now;

                        while (Recording)
                        {
                            string telemetryData = await ReceiveTelemetryDataAsync(telemetryClient);
                            telemetryData = telemetryData.TrimEnd('\n', '\r');
                            string csvLine = ConvertToCsvLine(telemetryData, startTime);
                            await logFile.WriteLineAsync(csvLine);
                        }

                        txtLog.AppendText("Writing complete to file : " + filePath + Environment.NewLine);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        async Task<string> ReceiveTelemetryDataAsync(UdpClient client)
        {
            var result = await client.ReceiveAsync();
            return Encoding.ASCII.GetString(result.Buffer);
        }

        string ConvertToCsvLine(string telemetryData, DateTime startTime)
        {
            var keyValuePairs = telemetryData.TrimEnd(';').Split(';');
            var values = keyValuePairs.Where(x => x.Contains(':')).Select(kvp => kvp.Split(':')[1]);
            var elapsedTime = (DateTime.Now - startTime).TotalMilliseconds;

            return elapsedTime.ToString() + "," + string.Join(",", values);
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
            //Console.ForegroundColor = text.Trim().Contains("Add") ? ConsoleColor.DarkGray : ConsoleColor.White;
            var msg = sb.ToString();
            //Log(msg, Console.ForegroundColor);
            txtLog.AppendText(msg + Environment.NewLine);
            await FileWriteAsync(msg);
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


    }
}
