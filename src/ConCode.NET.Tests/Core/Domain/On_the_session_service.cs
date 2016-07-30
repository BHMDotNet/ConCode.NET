using ConCode.NET.Domain;
using ConCode.NET.Domain.Interfaces;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace ConCode.NET.Tests.Core.Domain
{
    public class On_the_session_service 
    {

        [Fact]
        public void should_use_the_IConferenceDataProvider_when_calling_GetSessions()
        {
            var theSession = new Session();
            var theSessionList = new[] { theSession };
            var theDataProvider = new Mock<IConferenceDataProvider>();
            theDataProvider.Setup(x => x.Sessions).Returns(theSessionList.AsQueryable);
            var sessionService = new SessionService(theDataProvider.Object);
            var sessions = sessionService.GetSessions();

            Assert.NotNull(sessions);
            Assert.Contains(theSession, sessions);
        }

        [Fact]
        public void adding_a_session_should_use_the_IConferenceDataProvider_to_save()
        {
            var theSession = new Session() {
                Venue = new Venue(),
                Start = new DateTime(2016, 8, 4),
                Talk = new Talk(),
                TalkType = new TalkType(),
                Status = SessionStatus.Open
            };

            var theDataProvider = new Mock<IConferenceDataProvider>();
            var sessionService = new SessionService(theDataProvider.Object);
            theDataProvider.Setup(x => x.Sessions).Returns(new[] { new Session() }.AsQueryable());
            sessionService.AddSession(theSession);

            theDataProvider.Verify(x => x.AddSession(theSession), Times.AtLeastOnce());
        }

        [Fact]
        public void should_return_the_session_based_on_the_id() 
        {
            var theSessionId = 5;
            var session5 = new Session { Id = theSessionId };
            var session6 = new Session { Id = 6 };
            var session7 = new Session { Id = 7 };
            var session8 = new Session { Id = 8 };

            var theDataProvider = new Mock<IConferenceDataProvider>();
            theDataProvider.Setup(x => x.Sessions).Returns(new[] { session5, session6, session7, session8 }.AsQueryable);

            var sessionService = new SessionService(theDataProvider.Object);
            var theReturnedSession = sessionService.GetSession(theSessionId);
                
            Assert.Equal(theReturnedSession, session5);
        }
    }
}
