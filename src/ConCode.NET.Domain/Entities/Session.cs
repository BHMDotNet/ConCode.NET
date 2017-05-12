using System;

namespace ConCode.NET.Domain
{
    public class Session
    {
        public long Id { get; set; }
        public long TalkId { get; set; }
        public Talk Talk { get; set; }
        public DateTime Start { get; set; }
        // TODO: Move to Talk entity
        public TalkType TalkType { get; set; }
        public Venue Venue { get; set; }

        public SessionStatus Status {get;set;}
    }
    
}
