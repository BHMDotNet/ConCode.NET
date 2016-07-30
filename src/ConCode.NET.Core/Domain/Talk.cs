using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class Talk
    {
        public Talk()
        {
            Tags = new List<string>();
            AdditionalResources = new List<AdditionalResource>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public IEnumerable<User> Speakers { get; set; }
        public TalkLevel Level { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<AdditionalResource> AdditionalResources { get; set; }

        public int TimesPresented { get; set; }

        public long SpeakerInfoId { get; set; }
        public SpeakerInfo SpeakerInfo { get; set; }
    }
    
}
