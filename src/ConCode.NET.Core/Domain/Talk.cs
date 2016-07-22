using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class Talk
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
        public TalkLevel Level { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<Uri> AdditionalResources { get; set; }

        public int TimesPresented { get; set; }
    }
    
}
