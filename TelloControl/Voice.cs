using System.Diagnostics;
using System.Text;
using Google.Cloud.Speech.V1;
using NAudio.Wave;
using System.Net.Sockets;
using Timer = System.Threading.Timer;

namespace TelloControl
{

    public partial class Voice : Form
    {
        private WaveInEvent waveIn;
        private SpeechClient speechClient;
        private SpeechClient.StreamingRecognizeStream streamingCall;
        private bool Recording = false;
        static string timestamp = DateTime.Now.ToString("MMdd_HHmmss");
        static string baseFolder = "Logs";
        string csvFilePath = Path.Combine(baseFolder, $"TelloFlightLog_{timestamp}.csv"); // Log file path
        string txtFilePath = Path.Combine(baseFolder, $"TelloFlightLog_{timestamp}.txt"); // Log file path
        string countersFilePath = Path.Combine(baseFolder, $"Counters.txt"); // Log file path
        string delaysFilePath = Path.Combine(baseFolder, $"Delays.txt"); // Log file path
        string droneIP = "192.168.10.1"; // Tello IP
        int commandPort = 8889; // Command port
        int telemetryPort = 8890; // Telemetry data port

        public Voice()
        {
            InitializeComponent();
            // Path to your Google Cloud service account key file
            string credentialPath = "msc2024-411517-71868ce380c1.json";

            // Set the environment variable to authenticate
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
            speechClient = SpeechClient.Create();
            Task.Run(TelloHelper.RecordFlightLogAsync);
        }

        private async void siLK_Click(object sender, EventArgs e)
        {
            await StartRecognition("si-LK");
        }

        private async void enUS_Click(object sender, EventArgs e)
        {
            await StartRecognition("en-US");
        }

        public async Task StartRecognition(string languageCode)
        {
            console.AppendText($"{languageCode} Starting...\n");
            if (waveIn != null)
            {
                // Stop current recording if any
                waveIn.StopRecording();
                waveIn.Dispose();
            }

            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = languageCode
            };

            var streamingConfig = new StreamingRecognitionConfig
            {
                Config = config,
                InterimResults = false,
            };

            streamingCall = speechClient.StreamingRecognize();
            await streamingCall.WriteAsync(new StreamingRecognizeRequest
            {
                StreamingConfig = streamingConfig
            });

            waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(16000, 1)
            };
            waveIn.DataAvailable += async (sender, args) =>
            {
                await streamingCall.WriteAsync(new StreamingRecognizeRequest
                {
                    AudioContent = Google.Protobuf.ByteString.CopyFrom(args.Buffer, 0, args.BytesRecorded)
                });
            };

            waveIn.StartRecording();
            console.AppendText("Speak now...\n");

            var stopwatch = new Stopwatch();
            Task.Run(async () =>
            {
                await foreach (var response in streamingCall.GetResponseStream())
                {
                    stopwatch.Start();
                    foreach (var result in response.Results)
                    {
                        //if (result.IsFinal)
                        foreach (var alternative in result.Alternatives)
                        {
                            Invoke(new Action(() =>
                            {
                                console.AppendText($"Transcript: {alternative.Transcript}, Confidence: {alternative.Confidence}, Command : {TextCommandMapping.GetCommandClass(alternative.Transcript)}" + Environment.NewLine);
                                Log(delaysFilePath, $"Text delay,{stopwatch.ElapsedTicks}"); // 1 tick = 100ns 
                                console.ScrollToCaret();
                                IssueVoiceCommand(alternative.Transcript);
                                Log(delaysFilePath, $"Command delay,{stopwatch.ElapsedTicks}");
                                stopwatch.Reset();
                            }));
                        }
                    }
                }
            });
        }

        void IssueVoiceCommand(string command)
        {
            var dic = new Dictionary<string, string>
            {
                { "connect", "command" },
                { "take off", "takeoff" },
            };

            //List<(TimeSpan, string)> commands = TextCommandMapping.GetCommand(command);

            //KeyValuePair<string, string>? val = dic.FirstOrDefault(x => x.Key == command.Trim());
            //_ = IssueBtnCommandAndLog(val.Value.Key?.Length > 0 ? val.Value.Value.ToLower() : command.Trim().ToLower());
        }

        private void btnTelemetry_Click(object sender, EventArgs e)
        {
            var x = Recording ? RecordStart() : RecordStop();
            console.AppendText((TelloHelper.LoggingOn ? "Logging Started" : "Logging Finished") + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            console.AppendText("Connecting..." + Environment.NewLine);
            IssueBtnCommandAndLog("command");
        }

        async Task SendCommandAsync(string command, UdpClient client)
        {
            Log(txtFilePath, command);
            var commandBytes = Encoding.ASCII.GetBytes(command);
            await client.SendAsync(commandBytes, commandBytes.Length);
            var result = await client.ReceiveAsync();
            Log(txtFilePath, Encoding.ASCII.GetString(result.Buffer));
        }

        private async Task IssueBtnCommandAndLog(string command)
        {
            txtCommand.Text = command;
            if (chkRecordStart.Checked) RecordStart();
            using (var commandClient = new UdpClient())
            {
                commandClient.Connect(droneIP, commandPort);
                await SendCommandAsync(command, commandClient);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            RecordStart();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            RecordStop();
        }

        private async void btnEmergency_Click(object sender, EventArgs e)
        {
            await IssueBtnCommandAndLog("emergency");
        }

        private async Task RecordStart()
        {
            timestamp = DateTime.Now.ToString("MMdd_HHmmss");
            csvFilePath = Path.Combine(baseFolder, $"{txtPilot.Text}_{timestamp}_{txtCommand.Text}.csv");
            txtFilePath = Path.Combine(baseFolder, $"{txtPilot.Text}_{timestamp}_{txtCommand.Text}.txt");
            Recording = true;
            await RecordFlightLogAsync(telemetryPort, csvFilePath);
        }

        private async Task RecordStop() => Recording = false;

        async Task RecordFlightLogAsync(int telemetryPort, string filePath)
        {
            try
            {
                using (var telemetryClient = new UdpClient(telemetryPort))
                {
                    using (var logFile = new StreamWriter(filePath))
                    {
                        console.AppendText("Writing start to file : " + filePath + Environment.NewLine);
                        logFile.WriteLine("Pilot,timestamp_ms,command,condition,pitch,roll,yaw,vgx,vgy,vgz,templ,temph,tof,h,bat,baro,time,agx,agy,agz");
                        var startTime = DateTime.Now;

                        while (Recording)
                        {
                            string telemetryData = await ReceiveTelemetryDataAsync(telemetryClient);
                            telemetryData = telemetryData.TrimEnd('\n', '\r');
                            var elapsedTime = (DateTime.Now - startTime).TotalMilliseconds;
                            var csvLine = ConvertToCsvLine(telemetryData, startTime);
                            lblTemp.Text = $"{csvLine[6]}~{csvLine[7]} ℃";
                            lblBattery.Text = $"{csvLine[10]} %";
                            lblH.Text = $"{csvLine[9]} h";
                            lblTime.Text = $"{csvLine[12]} t";
                            await logFile.WriteLineAsync(string.Join(",", txtPilot.Text, elapsedTime.ToString(), txtCommand.Text, string.Join(",", csvLine)));
                        }

                        console.AppendText("Writing complete to file : " + filePath + Environment.NewLine);
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
            var ascii = Encoding.ASCII.GetString(result.Buffer);
            switch (ascii)
            {
                case "ok":
                case "error":
                case "error Not joystick":
                    Log(txtFilePath, ascii);
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

        public async Task Log(string filePath, string text, params string[] @params)
        {
            var sb = new StringBuilder();
            var prefix = $"{DateTime.Now:yy/MM/dd HH:mm:ss.fff},";
            sb.Append(prefix);
            sb.Append(text);
            foreach (var s in @params)
            {
                sb.AppendLine(s);
            }
            //Console.ForegroundColor = text.Trim().Contains("Add") ? ConsoleColor.DarkGray : ConsoleColor.White;
            var msg = sb.ToString();
            //Log(msg, Console.ForegroundColor);
            console.AppendText(msg + Environment.NewLine);
            await FileWriteAsync(filePath, msg);
            console.ScrollToCaret();
            Task.Delay(100);
        }

        public async Task FileWriteAsync(string filePath, string messaage, bool append = true)
        {
            using (FileStream stream = new FileStream(filePath, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    await sw.WriteLineAsync(messaage);
                }
            }
        }

        #endregion

        private void btnIncorrect_Click(object sender, EventArgs e)
        {
            Log(countersFilePath, $"Incorrect,{txtIncorrect.Text}");
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            Log(countersFilePath, $"Correct,");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Voice_Load(object sender, EventArgs e)
        {

        }

        private void txtIncorrect_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
