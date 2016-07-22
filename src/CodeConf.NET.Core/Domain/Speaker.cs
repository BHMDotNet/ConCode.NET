using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class Speaker : User
    {
        public IEnumerable<Talk> Talks { get; set; }

        public string Tagline { get; set; }


    }
}
