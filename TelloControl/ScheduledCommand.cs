using System.Text;

namespace TelloControl;

public class ScheduledCommand(string command, int delayMilliseconds)
{
    public string Command { get; set; } = command;
}