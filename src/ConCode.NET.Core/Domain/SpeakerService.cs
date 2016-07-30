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

        public void CreateSpeaker(User speaker)
        {
            _conferenceDataProvider.AddSpeaker(speaker);
        }

        public User GetSpeakerById(int userId)
        {
            return _conferenceDataProvider.Speakers.FirstOrDefault(s => s.Id == userId);
        }

        public IQueryable<User> GetSpeakers()
        {
            return _conferenceDataProvider.Speakers;
        }

        public void SaveSpeaker(User speaker)
        {
            _conferenceDataProvider.SaveSpeaker(speaker);
        }
    }
}
