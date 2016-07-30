using ConCode.NET.Domain;
using ConCode.NET.Domain.Interfaces;
using ConCode.NET.Web.Controllers;
using ConCode.NET.Web.Models.AttendeeViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace ConCode.NET.Tests.Web.Controllers.Attendee
{
    public class When_requesting_Index_on_AttendeeController
    {
        private AttendeeController _controller;
        private ViewResult _result;

        public When_requesting_Index_on_AttendeeController()
        {
            var theAttendee = new User
            {
                Id = 1001,
                FirstName = "Brandon"
            };

            var theAttendeeList = new[]
            {
                theAttendee
            };

            var sessionService = new Moq.Mock<IAttendeeService>();
            var httpContext = new Moq.Mock<IHttpContextAccessor>();

            sessionService.Setup(x => x.GetAttendeeByUsername("test123")).Returns(theAttendee);
            httpContext.Setup(x => x.HttpContext).Returns(new DefaultHttpContext
            {
                User = new System.Security.Claims.ClaimsPrincipal(new List<ClaimsIdentity>
                {
                    new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "test123")
                    })
                })
            });

            _controller = new AttendeeController(httpContext.Object, sessionService.Object);
        }

        public void Because()
        {
            _result = (ViewResult)_controller.Index();
        }

        [Fact]
        public void Should_provide_valid_Attendee_model_when_requesting_Index_view()
        {
            // Setup variables

            Because();

            // Checks
            Assert.NotNull(_result);
            Assert.NotNull(_result.Model);

            var resultModel = (AttendeeIndexViewModel)_result.Model;
            Assert.NotNull(resultModel);
            Assert.False(string.IsNullOrWhiteSpace(resultModel.FirstName));
            Assert.True(resultModel.Id > 0);
        }
    }
}
