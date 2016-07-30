using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class TalkResource
    {
        public long TalkId { get; set; }
        public Talk Talk { get; set; }
        public long ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}
