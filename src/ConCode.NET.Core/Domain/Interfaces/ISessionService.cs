using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public interface ISessionService
    {
        IQueryable<Session> GetSessions();

        void AddSession(Session session);

        Session GetSession(int sessionId);
    }
}
