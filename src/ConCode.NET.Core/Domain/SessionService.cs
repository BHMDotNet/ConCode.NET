using System.Linq;
using ConCode.NET.Core.Domain;
using CodeConf.NET.Core.Data;
using System;

namespace CodeConf.NET.Core.Domain
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
            _conferenceDataProvider.AddSession(session);
        }

        public IQueryable<Session> GetSessions()
        {
            return _conferenceDataProvider.Sessions;
        }
    }
}
