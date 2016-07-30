using ConCode.NET.Domain;
using ConCode.NET.Domain.Interfaces;
using ConCode.NET.Web.Controllers;
using ConCode.NET.Web.Models.SpeakerViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace ConCode.NET.Tests.Web.Controllers.Speaker
{
    public class When_requesting_Index_on_SpeakerController
    {
        private SpeakerController _controller;
        private ViewResult _result;

        public When_requesting_Index_on_SpeakerController()
        {
            var theSpeaker = new User
            {
                Id = 1,
                FirstName = "Brandon",
                Username = "test123"
            };

            var theSpeakerList = new[]
            {
                theSpeaker
            };

            var sessionService = new Moq.Mock<ISpeakerService>();
            var httpContext = new Moq.Mock<IHttpContextAccessor>();

            sessionService.Setup(x => x.GetSpeakerByUsername("test123")).Returns(theSpeaker);
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

            _controller = new SpeakerController(httpContext.Object, sessionService.Object);
        }

        public void Because()
        {
            _result = (ViewResult)_controller.Index();
        }

        [Fact]
        public void Should_provide_valid_Speaker_model_when_requesting_Index_view()
        {
            // Setup variables

            Because();

            // Checks
            Assert.NotNull(_result);
            Assert.NotNull(_result.Model);

            var resultModel = (SpeakerIndexViewModel)_result.Model;
            Assert.NotNull(resultModel);
            Assert.False(string.IsNullOrWhiteSpace(resultModel.FirstName));
            Assert.True(resultModel.Id > 0);
        }
    }
}
