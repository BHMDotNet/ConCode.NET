using ConCode.NET.Core.Data;
using System.Linq;

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
    }
}
