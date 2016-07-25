using System.Linq;
using Xunit;
using ConCode.NET.Core.Domain;
using Moq;
using ConCode.NET.Core.Data;

namespace CodeConf.NET.Tests.Core.Domain
{
    public class When_getting_sessions
    {
        private Mock<IConferenceDataProvider> _mockConferenceDataProvider;
        private IQueryable<Session> _sessions;
        private ISessionService _sessionService;
        private Session[] _testSessions;

        public When_getting_sessions()
        {
            // Context
            _mockConferenceDataProvider = new Mock<IConferenceDataProvider>();
            _testSessions = new[] {
                new Session { Id = 1, Venue = new Venue { Id = 1, Description = "Room 1" }, Talk = new Talk { Id = 1, Title = "Talk 1" } }
                };
            _mockConferenceDataProvider.Setup(x => x.Sessions).Returns(() => _testSessions.AsQueryable());
            _sessionService = new SessionService(_mockConferenceDataProvider.Object);

            // Because
            _sessions = _sessionService.GetSessions();
        }

        [Fact]
        public void Should_provide_sessions()
        {
            Assert.Equal(_testSessions, _sessions);
        }
    }
}
