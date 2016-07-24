using CodeConf.NET.Core.Domain;
using ConCode.NET.Web.Controllers;
using ConCode.NET.Web.Models.SessionViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CodeConf.NET.Tests.Web.Controllers.Session
{
    public class when_requesting_add_on_SessionController
    {
        [Fact]
        public void should_return_a_view_with_an_AddSessionViewModel()
        {
            var sessionService = new Mock<ISessionService>();
            var controller = new SessionController(sessionService.Object);

            var result = controller.Add();

            Assert.NotNull(result);
            Assert.IsType<AddSessionViewModel>(((ViewResult)result).Model);
        }
    }
}
