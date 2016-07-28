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

        public IQueryable<Attendee> GetAttendees()
        {
            return _conferenceDataProvider.Attendees;
        }

        public void SaveAttendee(Attendee model)
        {
            _conferenceDataProvider.SaveAttendee(model);
        }
    }
}
