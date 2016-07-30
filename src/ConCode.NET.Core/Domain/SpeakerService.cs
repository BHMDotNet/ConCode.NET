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
            return _conferenceDataProvider.GetSpeakers.FirstOrDefault(s => s.Id == userId);
        }

        public User GetSpeakerByUsername(string username)
        {
            return _conferenceDataProvider.GetSpeakers.FirstOrDefault(s => s.Username.Equals(username));
        }

        public IQueryable<User> GetSpeakers()
        {
            return _conferenceDataProvider.GetSpeakers;
        }

        public void SaveSpeaker()
        {
            _conferenceDataProvider.SaveSpeaker();
        }
    }
}
