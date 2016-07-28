using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain.Interfaces
{
    public interface IAttendeeService
    {
        IQueryable<Attendee> GetAttendees();

        void SaveAttendee(Attendee model);
    }
}
