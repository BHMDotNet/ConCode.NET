using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain.Interfaces
{
    public interface IAttendeeService
    {
        IQueryable<User> GetAttendees();

        User GetAttendeeByUsername(string username);

        void SaveAttendee();
    }
}
