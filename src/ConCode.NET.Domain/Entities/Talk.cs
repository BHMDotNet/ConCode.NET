using System.Collections.Generic;

namespace ConCode.NET.Domain
{
    public class Talk
    {
        public Talk()
        {
            Tags = new List<string>();
            TalkResources = new List<TalkResource>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public IEnumerable<User> Speakers { get; set; }
        public TalkLevel Level { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public List<TalkResource> TalkResources { get; set; }

        public int TimesPresented { get; set; }

        public long SpeakerInfoId { get; set; }
        public SpeakerInfo SpeakerInfo { get; set; }
    }
    
}
