using System.Collections.Generic;

namespace ConCode.NET.Domain
{
    public class SpeakerInfo
    {
        public long Id { get; set; }
        public List<Talk> Talks { get; set; }
        public string Tagline { get; set; }
        public long UserId { get; internal set; }
        public User User { get; internal set; }
    }
}
