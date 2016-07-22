using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class TalkVote
    {
        public Talk Talk { get; set; }
        public User User { get; set; }
        public bool? Liked { get; set; }
        public string Comment { get; set; }
    }
}
