using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace TelloCLI
{

    internal class Program
    {
        private static IPEndPoint _ipEndPoint;
        private const string TelloIp = "192.168.10.1"; // Tello's default IP address
        private const int TelloPort = 8889; // Tello's command port
        private const int ListenPort = 8890; // Tello's response port'
        public static string SessionId = DateTime.Now.ToString("MMdd_HHmmss");
        string _csvFilePath = SessionId + "_TelloFlightLog.csv"; // Log file path
        private static string _logFilepath = "";
        static UdpClient udpClient = new UdpClient(TelloIp, TelloPort);

        static void Main()
        {
            _logFilepath = Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).CodeBase.Replace("file:///", "")), "Logs", SessionId + ".txt");
            Directory.CreateDirectory(Path.GetDirectoryName(_logFilepath) ?? string.Empty);
            Log($"Session {SessionId} started");

            try
            {
                Task.Run(ListenAsync);

                udpClient.Connect(TelloIp, TelloPort);
                SendCommand(udpClient, "command");

                Log("Enter Tello command (e.g., takeoff, land, up 50):");

                while (true)
                {
                    string command = Console.ReadLine();
                    if (command.ToLower() == "exit")
                    {
                        break;
                    }

                    SendCommand(udpClient, command);
                }

                udpClient.Close();
            }
            catch (Exception e)
            {
                Log(e.Message);
                Log(e.ToString());
                throw;
            }
        }

        static void SendCommand(UdpClient udpClient, string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command);
            udpClient.Send(data, data.Length);

            _ipEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
            byte[] receivedData = udpClient.Receive(ref _ipEndPoint);
            string response = Encoding.ASCII.GetString(receivedData);

            Log("Response: " + response);
        }

        static async Task ListenAsync()
        {
            UdpClient listenClient = new UdpClient("", ListenPort);
            while (true)
            {
                var receivedData = await listenClient.ReceiveAsync();
                string response = Encoding.ASCII.GetString(receivedData.Buffer);
                Log("Received response: " + response);
            }
        }

        static async Task Listen()
        {
            UdpClient listenClient = new UdpClient("", ListenPort);
            while (true)
            {
                _ipEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
                byte[] receivedData = udpClient.Receive(ref _ipEndPoint);
                string response = Encoding.ASCII.GetString(receivedData);
                Log("Received response: " + response);
            }
        }

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
            //Console.WriteLine(msg, Console.ForegroundColor);
            Console.WriteLine(msg);
            await FileWriteAsync(msg);
        }

        public static async Task FileWriteAsync(string messaage, bool append = true)
        {
            using (FileStream stream = new FileStream(_logFilepath, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
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