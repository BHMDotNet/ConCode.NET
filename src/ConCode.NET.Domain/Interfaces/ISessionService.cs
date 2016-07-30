using System.Linq;

namespace ConCode.NET.Domain.Interfaces
{
    public interface ISessionService
    {
        IQueryable<Session> GetSessions();

        void AddSession(Session session);

        Session GetSession(int sessionId);
    }
}
