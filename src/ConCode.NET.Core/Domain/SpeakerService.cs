using ConCode.NET.Core.Data;
using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public class SpeakerService : ISpeakerService
    {
        private IConferenceDataProvider _conferenceDataProvider;

        public SpeakerService(IConferenceDataProvider conferenceDataProvider)
        {
            _conferenceDataProvider = conferenceDataProvider;
        }

        public IQueryable<Speaker> GetSpeakers()
        {
            return _conferenceDataProvider.Speakers;
        }
    }
}
