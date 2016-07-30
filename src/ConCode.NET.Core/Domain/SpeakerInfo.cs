using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class SpeakerInfo
    {
        public long Id { get; set; }
        List<Talk> _talks;
        public List<Talk> Talks
        {
            get
            {
                if (_talks == null)
                {
                    return new List<Talk>();
                }
                return _talks;
            }
            set { _talks = value; }
        }

        public string Tagline { get; set; }
        public long UserId { get; internal set; }
        public User User { get; internal set; }
    }
}
