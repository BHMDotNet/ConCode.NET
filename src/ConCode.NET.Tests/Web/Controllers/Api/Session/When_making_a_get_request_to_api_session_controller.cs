using ConCode.NET.Domain.Interfaces;
using ConCode.NET.Web.Controllers.Api;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConCode.NET.Tests.Web.Controllers.Api.Session
{
    public class When_making_a_get_request_to_api_session_controller
    {

        private ConCode.NET.Domain.Session theSession = new ConCode.NET.Domain.Session
        {
            Id = 5
        };

        private List<ConCode.NET.Domain.Session> theSessionList = new List<ConCode.NET.Domain.Session>
        {
            new ConCode.NET.Domain.Session(),
            new ConCode.NET.Domain.Session(),
            new ConCode.NET.Domain.Session(),
        };

        [Fact]
        public void should_return_full_list_of_sessions_when_no_id_is_specified()
        {
            var theSessionService = new Mock<ISessionService>();
            theSessionService.Setup(x => x.GetSessions()).Returns(theSessionList.AsQueryable());

            var controller = new SessionController(theSessionService.Object);

            var result = controller.Get();

            Assert.NotNull(result);
            Assert.Equal(theSessionList.Count(), result.Count());
        }

        [Fact]
        public void should_return_the_correct_session_when_id_is_specified()
        {
            theSessionList.Add(theSession);
            var theSessionService = new Mock<ISessionService>();
            theSessionService.Setup(x => x.GetSessions()).Returns(theSessionList.AsQueryable());

            var controller = new SessionController(theSessionService.Object);

            var result = controller.Get(theSession.Id);

            Assert.NotNull(result);
            Assert.Equal(theSession, result);
        }

        [Fact]
        public void should_return_null_when_session_does_not_exist()
        {
            var theSessionService = new Mock<ISessionService>();
            theSessionService.Setup(x => x.GetSessions()).Returns(theSessionList.AsQueryable());

            var controller = new SessionController(theSessionService.Object);

            var result = controller.Get(theSession.Id);

            Assert.Null(result);
        }
    }
}
