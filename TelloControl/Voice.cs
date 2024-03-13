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
        private static UdpClient commandClient = new UdpClient();

        public Voice()
        {
            InitializeComponent();

            // Path to your Google Cloud service account key file
            string credentialPath = "msc2024-411517-71868ce380c1.json";

            // Set the environment variable to authenticate
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
            speechClient = SpeechClient.Create();
            Task.Run(TelloHelper.RecordFlightLogAsync);

            commandClient.Connect(droneIP, commandPort);
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
            AppendConsole($"{languageCode} Starting...");
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
                LanguageCode = languageCode,

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
            AppendConsole("Speak now...");

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
                                //AppendConsole($"Transcript: {alternative.Transcript}, Confidence: {alternative.Confidence}, Command : {TextCommandMapping.GetCommandClass(alternative.Transcript)}");
                                Log(delaysFilePath, $"Text delay,{stopwatch.ElapsedTicks}", true); // 1 tick = 100ns 
                                IssueVoiceCommand(alternative.Transcript);
                                Log(delaysFilePath, $"Command delay,{stopwatch.ElapsedTicks}", true);
                                stopwatch.Reset();
                            }));
                        }
                    }
                }
            });
        }

        private async Task IssueVoiceCommand(string command)
        {
            try
            {
                var commandClass = TextCommandMapping.GetCommandClass(command);
                if (commandClass!= "-")
                {
                    cmbCommand.Text = commandClass;
                }

                var records = TextCommandMapping.GetCommand(commandClass);
                AppendConsole($"{Environment.NewLine}\"{command}\" -> {commandClass}");
                if (records.Count > 0)
                {
                    var start = records.First().Time;

                    records = records.Select(x =>
                    {
                        var span = x.Time - start;
                        x.ticks = Convert.ToInt64(span);
                        x.delayFromPreviousMS = x.Time == 0
                            ? 0
                            : (int)((x.Time - records.Where(z => z.Time < x.Time)?.Max(z => z.Time)) ?? 0);
                        return x;
                    }).ToList();
                }
                else
                {
                    AppendConsole("??? Unidentified Command: " + command);
                    records.Add(new CommandData() { Time = 0, RCCommand = "rc 0 0 0 0", ticks = 0, delayFromPreviousMS = 0 });
                }

                await DelayExecution(records, commandClient);

            }
            catch (Exception e)
            {
                AppendConsole("!!! " + e);
            }
        }

        private async Task DelayExecution(List<CommandData> data, UdpClient udpClient)
        {
            List<ScheduledCommand> commands = data.Select(x => new ScheduledCommand(x.RCCommand, x.delayFromPreviousMS ?? 0)).ToList();

            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Task> tasks = new List<Task>();

            foreach (var command in data)
            {
                await Task.Delay(command.delayFromPreviousMS ?? 0);
                await udpClient.SendAsync(command.commandBytes, command.commandBytes.Length); // Send UDP packet
                AppendConsole($"{command.delayFromPreviousMS} : {command.RCCommand}");
            }

            stopwatch.Stop();
            AppendConsole("Command executed.\nSpeak now...");
        }

        private void btnTelemetry_Click(object sender, EventArgs e)
        {
            var x = Recording ? RecordStart() : RecordStop();
            AppendConsole((TelloHelper.LoggingOn ? "Logging Started" : "Logging Finished"));
            console.ScrollToCaret();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            AppendConsole("Connecting...");
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
            cmbCommand.Text = command;
            if (chkRecordStart.Checked) RecordStart();
            commandClient.Connect(droneIP, commandPort);
            await SendCommandAsync(command, commandClient);
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
            csvFilePath = Path.Combine(baseFolder, $"{txtPilot.Text}_{timestamp}_{cmbCommand.Text}.csv");
            txtFilePath = Path.Combine(baseFolder, $"{txtPilot.Text}_{timestamp}_{cmbCommand.Text}.txt");
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
                        AppendConsole("Writing start to file : " + filePath);
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
                            await logFile.WriteLineAsync(string.Join(",", txtPilot.Text, elapsedTime.ToString(), cmbCommand.Text, string.Join(",", csvLine)));
                        }

                        AppendConsole("Writing complete to file : " + filePath);
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

        private async Task AppendConsole(string text)
        {
            console.AppendText(text + Environment.NewLine);
            console.ScrollToCaret();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        /// <param name="params">"send silent to not show on console"</param>
        /// <returns></returns>
        public async Task Log(string filePath, string text, bool? silent = false, params string[] @params)
        {
            var sb = new StringBuilder();
            var prefix = $"{DateTime.Now:HH:mm:ss.fff},";
            sb.Append(prefix);
            sb.Append(text);
            foreach (var s in @params)
            {
                sb.AppendLine(s);
            }
            //Console.ForegroundColor = text.Trim().Contains("Add") ? ConsoleColor.DarkGray : ConsoleColor.White;
            var msg = sb.ToString();
            //Log(msg, Console.ForegroundColor);
            if (silent != true)
                AppendConsole(msg);

            await FileWriteAsync(filePath, msg);
            Task.Delay(150);
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
            Log(countersFilePath, $"Incorrect,{cmbAccuracyNote.Text}");
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            Log(countersFilePath, $"Correct,");
        }

        private void btnIncorrectQuick_Click(object sender, EventArgs e)
        {
            Log(countersFilePath, $"Incorrect,{((Button)sender).Text}");
        }
    }
}
