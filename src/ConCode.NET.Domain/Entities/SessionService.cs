using ConCode.NET.Domain.Interfaces;
using System.Linq;

namespace ConCode.NET.Domain
{
    public class SessionService : ISessionService
    {
        private IConferenceDataProvider _conferenceDataProvider;

        public SessionService(IConferenceDataProvider conferenceDataProvider)
        {
            _conferenceDataProvider = conferenceDataProvider;
        }

        public void AddSession(Session session)
        {
            var maxSessionId = _conferenceDataProvider.Sessions.Max(x => x.Id);
            session.Id = maxSessionId + 1;
            _conferenceDataProvider.AddSession(session);
        }

        public IQueryable<Session> GetSessions()
        {
            return _conferenceDataProvider.Sessions;
        }

        public Session GetSession(int sessionId)
        {
            return _conferenceDataProvider.Sessions.FirstOrDefault(x => x.Id == sessionId);
        }
    }
}
