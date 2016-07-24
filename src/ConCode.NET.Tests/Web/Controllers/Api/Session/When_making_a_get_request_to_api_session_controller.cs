using CodeConf.NET.Web.Controllers.Api;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CodeConf.NET.Core.Domain;
using Moq;

namespace CodeConf.NET.Tests.Web.Controllers.Api.Session
{
    public class When_making_a_get_request_to_api_session_controller
    {

        private ConCode.NET.Core.Domain.Session theSession = new ConCode.NET.Core.Domain.Session
        {
            Id = 5
        };

        private List<ConCode.NET.Core.Domain.Session> theSessionList = new List<ConCode.NET.Core.Domain.Session>
        {
            new ConCode.NET.Core.Domain.Session(),
            new ConCode.NET.Core.Domain.Session(),
            new ConCode.NET.Core.Domain.Session(),
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
