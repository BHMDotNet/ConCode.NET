using ConCode.NET.Core.Data;
using System.Linq;
using System;

namespace ConCode.NET.Core.Domain
{
    public class SpeakerService : ISpeakerService
    {
        private IConferenceDataProvider _conferenceDataProvider;

        public SpeakerService(IConferenceDataProvider conferenceDataProvider)
        {
            _conferenceDataProvider = conferenceDataProvider;
        }

        public void CreateSpeaker(Speaker speaker)
        {
            _conferenceDataProvider.AddSpeaker(speaker);
        }

        public IQueryable<Speaker> GetSpeakers()
        {
            return _conferenceDataProvider.Speakers;
        }

        public void SaveSpeaker(Speaker speaker)
        {
            _conferenceDataProvider.SaveSpeaker(speaker);
        }
    }
}
