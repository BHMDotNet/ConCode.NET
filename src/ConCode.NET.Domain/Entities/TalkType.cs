using System;

namespace ConCode.NET.Domain
{
    public class TalkType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get { return TimeSpan.FromTicks(LengthInTicks); } set { LengthInTicks = value.Ticks; } }
        public long LengthInTicks { get; set; }
    }
}
