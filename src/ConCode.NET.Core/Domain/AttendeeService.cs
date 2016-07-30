using ConCode.NET.Core.Data;
using ConCode.NET.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
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
