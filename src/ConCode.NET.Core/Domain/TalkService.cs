using ConCode.NET.Core.Data;
using System.Linq;
using System.Collections.Generic;

namespace ConCode.NET.Core.Domain
{
    public class TalkService : ITalkService
    {
        private IConferenceDataProvider _conferenceDataProvider;

        public TalkService(IConferenceDataProvider conferenceDataProvider)
        {
            _conferenceDataProvider = conferenceDataProvider;
        }

        public IQueryable<Talk> GetTalks()
        {
            return _conferenceDataProvider.Talks;
        }

        public Talk GetTalk(int talkId)
        {
            return _conferenceDataProvider.Talks.FirstOrDefault(x => x.Id == talkId);
        }

        public IEnumerable<TalkType> GetTalkTypes()
        {
            return _conferenceDataProvider.TalkTypes;
        }

        public TalkType GetTalkType(int talkTypeId)
        {
            return _conferenceDataProvider.TalkTypes.FirstOrDefault(x => x.Id == talkTypeId);
        }
    }
}
