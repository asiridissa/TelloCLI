using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Net;
using PrecisionTiming;
using System.Diagnostics;

namespace Replay
{
    internal class Program
    {
        private const string droneIP = "192.168.10.1"; // Tello IP
        private const int commandPort = 8889; // Command port
        private static Timer timer = new Timer(1000);
        private static UdpClient commandClient = new UdpClient();
        static int telemetryPort = 8890; // Telemetry data port

        private static Timer commandTimer;

        private static bool trueFrequency = false; //milli seconds

        static async Task Main(string[] args)
        {


            commandClient.Connect(droneIP, commandPort);

            await SendCommandAsync("command", commandClient);
            await Task.Delay(3000);
            await SendCommandAsync("takeoff", commandClient);
            await Task.Delay(3000);
            await SendCommandAsync("rc 0 0 0 0", commandClient);
            await Task.Delay(3000);

            var rcs = ReadRemoteLogData("log.txt", commandClient);
            await DelayExecution(rcs, commandClient);
            //await SendRCCommands(rcs, commandClient);
            //await SendCommandAsync("battery?", commandClient);
            //await Task.Delay(2000);
            //await SendCommandAsync("rc 0 0 0 0", commandClient);
            //await Task.Delay(2000);
            //await SendCommandAsync("rc 0 0 0 0", commandClient);
            //await Task.Delay(2000);
            await SendCommandAsync("land", commandClient);
            await Task.Delay(3000);

            //await Start(commandClient);

            //Task.WaitAll(ReceiveTelemetryDataAsync(), Start(commandClient));

            //Console.WriteLine("Press \'q\' to quit the sample.");
            //while (Console.Read() != 'q') ;
            commandClient.Dispose();

            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();

            //commandTimer.Stop();
            //commandTimer.Dispose();
        }

        //private static async Task OnTimedEvent(Object source, ElapsedEventArgs e, string command)
        //{
        //    // This is where you would send your command. For demonstration, we'll just print the current time.
        //    Console.WriteLine("{0:HH:mm:ss.fff}: {1}", e.SignalTime, command);
        //    await SendAsync(command);
        //}

        //static Task Start(UdpClient commandClient)
        //{
        //    string filePath = "Left.csv"; // Update this path
        //    var records = ReadTelemetryData(filePath);
        //    var skip = 1;

        //    var commands = GenerateCommands(records);

        //    var rounds = commands.Count;
        //    var running = 0;
        //    commandTimer = new Timer();
        //    commandTimer.Interval = trueFrequency ? 100 : 1000;
        //    commandTimer.Elapsed += async (o, s) =>
        //    {
        //        await OnTimedEvent(o, s, commands.Skip(running).First());
        //        running++;
        //        if (running >= rounds)
        //        {
        //            Console.WriteLine("timer disabled");
        //            commandTimer.Enabled = false;
        //        }
        //    };
        //    commandTimer.Enabled = true;

        //    return Task.CompletedTask;
        //}


        //static List<TelemetryData> ReadTelemetryData(string filePath)
        //{
        //    using (var reader = new StreamReader(filePath))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        var records = csv.GetRecords<TelemetryData>().ToList();
        //        return records;
        //    }
        //}


        //static async Task SendAsync(string command)
        //{
        //    using (var commandClient = new UdpClient())
        //    {
        //        commandClient.Connect(droneIP, commandPort);
        //        await SendCommandAsync(command, commandClient);
        //    }
        //}

        //static List<string> GenerateCommands(List<TelemetryData> data)
        //{
        //    if (!trueFrequency)
        //    {
        //        data = data.GroupBy(x => x.time).Select(x => new TelemetryData()
        //        {
        //            time = x.Key,
        //            agx = (int?)x.Average(z => z.agx),
        //            agy = (int?)x.Average(z => z.agy),
        //            agz = (int?)x.Average(z => z.agz),
        //            h = x.Last().h,
        //            yaw = x.Last().yaw
        //        }).ToList();
        //    }
        //    data.Add(new TelemetryData()
        //    {
        //        agy = 0,
        //        agx = 0,
        //        h = 0,
        //        yaw = 0,
        //    });
        //    return data.Select(x => $"rc {x.agy} {x.agx} {x.h} {x.yaw}").ToList();
        //}

        //static string TranslateToCommand(TelemetryData previousState, TelemetryData currentState)
        //{
        //    // Simplified example: Decide based on height difference
        //    if (currentState.h > previousState.h)
        //    {
        //        return $"up {currentState.h - previousState.h}";
        //    }
        //    else if (currentState.h < previousState.h)
        //    {
        //        return $"down {previousState.h - currentState.h}";
        //    }

        //    return string.Empty; // No significant change
        //}

        static async Task SendCommandAsync(string command, UdpClient commandClient)
        {
            var commandBytes = Encoding.ASCII.GetBytes(command);
            await commandClient.SendAsync(commandBytes, commandBytes.Length);
        }

        //static async Task ReceiveTelemetryDataAsync()
        //{
        //    using (var client = new UdpClient(telemetryPort))
        //    {
        //        while (true)
        //        {
        //            var result = await client.ReceiveAsync();
        //            var ascii = Encoding.ASCII.GetString(result.Buffer);
        //            //if (!ascii.Contains("pitch"))
        //            {
        //                Console.WriteLine(ascii);
        //            }
        //        }
        //    }
        //}

        static List<RCCommandData> ReadRemoteLogData(string filePath, UdpClient client)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null
            }))
            {
                var frequencyMilliseconds = 1;
                var records = csv.GetRecords<RCCommandData>().ToList();
                var start = records.First().Time;
                var end = records.Last().Time;
                TimeSpan timeSpan = end.Value - start.Value;
                var timeSlots = Convert.ToInt32(timeSpan.TotalMilliseconds / frequencyMilliseconds) + 1;

                records = records.Select(x =>
                {
                    var span = x.Time.Value - start;
                    x.ticks = span.Value.Ticks;
                    x.delayFromPreviousMS = (int)((x.Time - records.Where(z => z.Time < x.Time).Max(z => z.Time))?.TotalMilliseconds ?? 0);
                    return x;
                }).ToList();

                //var timer = new PrecisionTimer();
                //var ticks = 0;

                //timer.SetInterval(() =>
                //{
                //    var record = records.LastOrDefault(x => x.ticks / 10000 == ticks);
                //    if (record != null)
                //    {
                //        Console.ForegroundColor = ConsoleColor.Cyan;
                //        Console.WriteLine($"{ticks}: {record.fullCommand}");
                //        SendCommandAsync(record.fullCommand, commandClient);
                //    }
                //    else
                //    {
                //        //Console.WriteLine($"{ticks}: rc 0 0 0 0");
                //    }

                //    ticks++;
                //    timeSlots--;
                //    if (timeSlots < 1)
                //    {
                //        timer.Stop();
                //        timer.Dispose();
                //        Console.ForegroundColor = ConsoleColor.Red;
                //        Console.WriteLine("End");
                //        Console.ForegroundColor = ConsoleColor.White;
                //    }
                //}, frequencyMilliseconds, false);

                //timer.Start();

                return records;
            }
        }

        //static Task SendRCCommands(List<RCCommandData> commands, UdpClient udpClient)
        //{
        //    // High-resolution timer settings
        //    var stopwatch = new Stopwatch();
        //    int runningCount = 0;
        //    var running = true;
        //    int commandCount = commands.Count;

        //    var thread = new Thread(() =>
        //    {
        //        stopwatch.Start();
        //        while (running)
        //        {
        //            var tick = stopwatch.ElapsedTicks;
        //            var isPerfectMillisecond = tick % 10000 == 0;
        //            if (isPerfectMillisecond)
        //            {
        //                var comm = commands.LastOrDefault(x => x.ticks == tick);
        //                if (comm != null)
        //                {
        //                    Console.WriteLine(comm.fullCommand);
        //                    //udpClient.Send(comm.fullCommandBytes, comm.fullCommandBytes.Length); // Send UDP packet
        //                    runningCount++;
        //                }
        //                if (runningCount >= commandCount)
        //                {
        //                    Console.WriteLine("End");
        //                    running = false;
        //                }
        //            }

        //            Thread.Sleep(0); // Yield to other threads
        //        }
        //    });

        //    thread.Priority = ThreadPriority.Highest; // Set thread priority to highest to attempt more precise timing
        //    thread.Start();
        //    return Task.CompletedTask;
        //}

        static async Task DelayExecution(List<RCCommandData> data, UdpClient udpClient)
        {
            List<ScheduledCommand> commands = data.Select(x => new ScheduledCommand(x.fullCommand, x.delayFromPreviousMS ?? 0)).ToList();

            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Task> tasks = new List<Task>();

            //await ExecuteCommandsInSequence(commands, stopwatch);

            //foreach (var command in commands)
            //{
            //    var task = ExecuteCommandAsync(command, stopwatch);
            //    tasks.Add(task);
            //}

            foreach (var command in data)
            {
                await Task.Delay(command.delayFromPreviousMS ?? 0);
                Console.WriteLine($"{command.fullCommand} executed at {stopwatch.ElapsedMilliseconds} ms {DateTime.Now.TimeOfDay.TotalMilliseconds}");
                await udpClient.SendAsync(command.fullCommandBytes, command.fullCommandBytes.Length); // Send UDP packet
            }

            //await Task.WhenAll(tasks); // Wait for all commands to be executed

            stopwatch.Stop();
            Console.WriteLine("All commands executed.");
        }

        //static async Task ExecuteCommandsInSequence(List<ScheduledCommand> commands, Stopwatch stopwatch)
        //{
        //    foreach (var command in commands)
        //    {
        //        await Task.Delay(command.DelayMilliseconds); // Wait for the time difference
        //        Console.WriteLine($"{command.Command} executed at {stopwatch.ElapsedMilliseconds} ms {DateTime.Now.TimeOfDay.TotalMilliseconds}");
        //        // Here, replace the console output with the actual command execution logic
        //    }
        //}

        //static async Task ExecuteCommandAsync(ScheduledCommand scheduledCommand, Stopwatch stopwatch)
        //{
        //    await Task.Delay(scheduledCommand.DelayMilliseconds);
        //    Console.WriteLine($"{scheduledCommand.Command} executed at {stopwatch.ElapsedMilliseconds} ms {DateTime.Now.TimeOfDay.TotalMilliseconds}");
        //    // Here, replace the console output with the actual command execution logic
        //}
    }
}
