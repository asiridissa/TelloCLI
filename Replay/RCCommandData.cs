using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Replay
{
    public class RCCommandData
    {
        public string? timeString { get; set; }
        public string? command { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int d { get; set; }
        public DateTime? Time { get => Convert.ToDateTime(timeString); }
        //public TimeSpan? Tick { get; set; }
        public long? ticks { get; set; }
        public int? delayFromPreviousMS { get; set; }
        public string fullCommand => $"{command} {a} {b} {c} {d}";
        public byte[] fullCommandBytes => Encoding.UTF8.GetBytes(fullCommand);

    }
}
