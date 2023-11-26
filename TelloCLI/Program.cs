using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TelloCLI
{

    internal class Program
    {
        public static UdpClient UdpClient = new UdpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            try
            {
                UdpClient.Connect("192.168.10.1", 8889);
                await Loop("command");

                while (true)
                {
                    var command = Console.ReadLine();
                    switch (true)
                    {
                        case true when command == "end":
                            await Loop("land");
                            return;
                        case true when !string.IsNullOrWhiteSpace(command):
                            await Loop(command);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                UdpClient.Close();
            }
            finally
            {
                UdpClient.Close();
            }
        }

        static async Task Loop(string command)
        {
            // Sends a message to the host to which you have connected.
            Byte[] sendBytes = Encoding.ASCII.GetBytes(command);
            UdpClient.Send(sendBytes, sendBytes.Length);
            await Listen(9000);
        }

        static Task Listen(int port)
        {
            var udpListner = new UdpClient(port);

            //IPEndPoint object will allow us to read datagrams sent from any source.
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, port);

            // Blocks until a message returns on this socket from a remote host.
            Byte[] receiveBytes = udpListner.Receive(ref remoteIpEndPoint);
            string returnData = Encoding.ASCII.GetString(receiveBytes);

            // Uses the IPEndPoint object to determine which of these two hosts responded.
            Console.WriteLine($"Response {remoteIpEndPoint.Address}:{remoteIpEndPoint.Port} :- {returnData}");
            udpListner.Close();
            return Task.CompletedTask;
        }

        //static Task Status()
        //{
        //    //IPEndPoint object will allow us to read datagrams sent from any source.
        //    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 8890);

        //    // Blocks until a message returns on this socket from a remote host.
        //    Byte[] receiveBytes = UdpClient.Receive(ref RemoteIpEndPoint);
        //    string returnData = Encoding.ASCII.GetString(receiveBytes);

        //    // Uses the IPEndPoint object to determine which of these two hosts responded.
        //    Console.WriteLine($"Status {RemoteIpEndPoint.Address}:{RemoteIpEndPoint.Port} :- {returnData}");
        //    return Task.CompletedTask;
        //}

        //private static async Task StatusListener(int listenPort)
        //{
        //    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

        //    try
        //    {
        //        while (true)
        //        {
        //            Console.WriteLine("Waiting for broadcast");
        //            byte[] bytes = UdpClient.Receive(ref groupEP);
        //            Console.WriteLine($"Received {groupEP.Address}:{groupEP.Port} :- {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
        //        }
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //    finally
        //    {
        //        UdpClient.Close();
        //    }
        //}

    }
}