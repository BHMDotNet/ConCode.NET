using System;

namespace ConCode.NET.Domain
{
    public class Session
    {
        public int Id { get; set; }
        public Talk Talk { get; set; }
        public DateTime Start { get; set; }
        public TalkType TalkType { get; set; }
        public Venue Venue { get; set; }

        public SessionStatus Status {get;set;}
    }
    
}
