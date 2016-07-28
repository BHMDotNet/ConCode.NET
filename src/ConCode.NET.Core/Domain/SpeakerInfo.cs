using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class SpeakerInfo
   {
        public int Id { get; set; }
        public IEnumerable<Talk> Talks { get; set; }

        public string Tagline { get; set; }
        public int UserId { get; internal set; }
        public User User { get; internal set; }
    }
}
