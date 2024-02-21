namespace Replay;

public class ScheduledCommand
{
    public string Command { get; set; }
    public int DelayMilliseconds { get; set; }

    public ScheduledCommand(string command, int delayMilliseconds)
    {
        Command = command;
        DelayMilliseconds = delayMilliseconds;
    }
}