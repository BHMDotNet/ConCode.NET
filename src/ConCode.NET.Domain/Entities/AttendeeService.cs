using ConCode.NET.Domain.Interfaces;
using System.Linq;

namespace ConCode.NET.Domain
{
    public class AttendeeService : IAttendeeService
    {
        private IConferenceDataProvider _conferenceDataProvider;

        public AttendeeService(IConferenceDataProvider conferenceDataProvider)
        {
            _conferenceDataProvider = conferenceDataProvider;
        }

        public User GetAttendeeByUsername(string username)
        {
            return _conferenceDataProvider.GetAttendees.FirstOrDefault(s => s.Username.Equals(username));
        }

        public IQueryable<User> GetAttendees()
        {
            return _conferenceDataProvider.GetAttendees;
        }

        public void SaveAttendee()
        {
            _conferenceDataProvider.SaveAttendee();
        }
    }
}
