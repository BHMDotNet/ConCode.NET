using CodeConf.NET.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ConCode.NET.Core.Domain;
using Moq;

namespace CodeConf.NET.Tests.Core.Domain
{
    public class When_getting_sessions
    {
        //private Mock<IConferenceDataProvider> _conferenceDataProvider;
        private IQueryable<Session> _sessions;
        private ISessionService _sessionService;

        public When_getting_sessions()
        {
            // Context
            _sessionService = new SessionService();
            //_conferenceDataProvider = new Mock<IConferenceDataProvider>();
            //_conferenceDataProvider.Setup(x => x.Sessions)


            // Because
            _sessions = _sessionService.GetSessions();

        }
        public void Should_provide_sessions()
        {

        }

    }
}
