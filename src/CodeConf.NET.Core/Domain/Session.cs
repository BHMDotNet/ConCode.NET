using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class Session
    {
        public int Id { get; set; }
        public Talk Talk { get; set; }
        public DateTime Start { get; set; }
        public TalkType TalkType { get; set; }
        public Venue Venue { get; set; }
    }
    
}