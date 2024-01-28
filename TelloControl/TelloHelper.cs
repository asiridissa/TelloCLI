using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TelloControl
{
    public static class TelloHelper
    {
        static string timestamp = DateTime.Now.ToString("MMdd_HHmmss");
        static string csvFilePath = $"TelloFlightLog_{timestamp}.csv"; // Log file path
        static string txtFilePath = $"TelloFlightLog_{timestamp}.txt"; // Log file path

        static string droneIP = "192.168.10.1"; // Tello IP
        static int commandPort = 8889; // Command port
        static int telemetryPort = 8890; // Telemetry data port

        public static bool LoggingOn = false;

        public static UdpClient commandClient = new UdpClient();

        public static async Task Connect()
        {
            LoggingOn = true;
            using (commandClient)
            {
                commandClient.Connect(droneIP, commandPort);
                await SendCommandAsync("command", commandClient);
            }
        }

        static async Task Control1()
        {
            using (commandClient)
            {
                commandClient.Connect(droneIP, commandPort);

                var controlTask = ControlDroneAsync(commandClient);

                await Task.WhenAll(controlTask);
            }
        }

        #region FlightControl
        static async Task ControlDroneAsync(UdpClient client)
        {
            await SendCommandAsync("command", client);
            await SendCommandAsync("takeoff", client);
            await Task.Delay(5000); // Allow time for takeoff

            await SendCommandAsync("go 0 20 0 20", client); // Turn left
            await Task.Delay(5000); // Allow time for turn

            await SendCommandAsync("go 20 0 0 20", client); // Turn left
            await Task.Delay(5000); // Allow time for turn

            await SendCommandAsync("land", client); // Land
        }

        static async Task SendCommandAsync(string command, UdpClient client)
        {
            Log(command);
            var commandBytes = Encoding.ASCII.GetBytes(command);
            await client.SendAsync(commandBytes, commandBytes.Length);
        }
        #endregion

        #region FlightLog

        public static async Task RecordFlightLogAsync()
        {
            await SendCommandAsync("command", commandClient);

            using (var telemetryClient = new UdpClient(telemetryPort))
            {
                using (var logFile = new StreamWriter(csvFilePath))
                {
                    logFile.WriteLine("timestamp_ms,pitch,roll,yaw,vgx,vgy,vgz,templ,temph,tof,h,bat,baro,time,agx,agy,agz");
                    var startTime = DateTime.Now;

                    while (LoggingOn)
                    {
                        string telemetryData = await ReceiveTelemetryDataAsync(telemetryClient);
                        telemetryData = telemetryData.TrimEnd('\n', '\r');
                        string csvLine = ConvertToCsvLine(telemetryData, startTime);
                        logFile.WriteLine(csvLine);
                        await Task.Delay(100);
                    }
                }
            }
        }

        static async Task<string> ReceiveTelemetryDataAsync(UdpClient client)
        {
            var result = await client.ReceiveAsync();
            return Encoding.ASCII.GetString(result.Buffer);
        }

        static string ConvertToCsvLine(string telemetryData, DateTime startTime)
        {
            var keyValuePairs = telemetryData.TrimEnd(';').Split(';');
            var values = keyValuePairs.Where(x => x.Contains(':')).Select(kvp => kvp.Split(':')[1]);
            var elapsedTime = (DateTime.Now - startTime).TotalMilliseconds;

            return elapsedTime.ToString() + "," + string.Join(",", values);
        }
        #endregion

        #region Logs

        public static async Task Log(string text, params string[] @params)
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
            Console.WriteLine(msg);
            await FileWriteAsync(msg);
        }

        public static async Task FileWriteAsync(string messaage, bool append = true)
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
