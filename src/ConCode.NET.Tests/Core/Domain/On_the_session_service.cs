using ConCode.NET.Core.Data;
using ConCode.NET.Core.Domain;
using Moq;
using System.Linq;
using Xunit;
using ConCode.NET.Core.Domain;

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
    }
}
