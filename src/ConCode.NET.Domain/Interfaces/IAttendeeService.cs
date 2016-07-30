using System.Linq;

namespace ConCode.NET.Domain.Interfaces
{
    public interface IAttendeeService
    {
        IQueryable<User> GetAttendees();

        User GetAttendeeByUsername(string username);

        void SaveAttendee();
    }
}
