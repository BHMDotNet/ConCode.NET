using ConCode.NET.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ConCode.NET.Domain
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
            return _conferenceDataProvider.GetTalks;
        }

        public Talk GetTalk(int talkId)
        {
            return _conferenceDataProvider.GetTalks.FirstOrDefault(x => x.Id == talkId);
        }

        public IEnumerable<TalkType> GetTalkTypes()
        {
            return _conferenceDataProvider.TalkTypes;
        }

        public TalkType GetTalkType(int talkTypeId)
        {
            return _conferenceDataProvider.TalkTypes.FirstOrDefault(x => x.Id == talkTypeId);
        }

        public void AddTalk(Talk talk)
        {
            var maxId = _conferenceDataProvider.GetTalks.Max(x => x.Id);
            talk.Id = maxId + 1;
            _conferenceDataProvider.AddTalk(talk);
        }
    }
}
