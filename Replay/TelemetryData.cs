using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Replay
{
    public class TelemetryData
    {
        //Pilot,timestamp_ms,command,pitch,roll,yaw,vgx,vgy,vgz,templ,temph,tof,h,bat,baro,time,agx,agy,agz
        public string? Pilot { get; set; }
        public decimal? timestamp_ms { get; set; }
        public string? command { get; set; }
        public int? pitch { get; set; }
        public int? roll { get; set; }
        public int? yaw { get; set; }
        public int? vgx { get; set; }
        public int? vgy { get; set; }
        public int? vgz { get; set; }
        public int? templ { get; set; }
        public int? temph { get; set; }
        public int? tof { get; set; }
        public int? h { get; set; }
        public int? bat { get; set; }
        public decimal? baro { get; set; }
        public int? time { get; set; }
        public float? agx { get; set; }
        public float? agy { get; set; }
        public float? agz { get; set; }
    }
}
