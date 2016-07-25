using ConCode.NET.Core.Domain;
using ConCode.NET.Web.Controllers;
using ConCode.NET.Web.Models.SpeakerViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;
using SpeakerPoco = ConCode.NET.Core.Domain.Speaker;

namespace ConCode.NET.Tests.Web.Controllers.Speaker
{
    public class When_requesting_Index_on_SpeakerController
    {
        private SpeakerController _controller;
        private ViewResult _result;

        public When_requesting_Index_on_SpeakerController()
        {
            var theSpeaker = new SpeakerPoco
            {
                Id = 1,
                FirstName = "Brandon"
            };

            var theSpeakerList = new[]
            {
                theSpeaker
            };

            var sessionService = new Moq.Mock<ISpeakerService>();
            sessionService.Setup(x => x.GetSpeakers()).Returns(theSpeakerList.AsQueryable());

            _controller = new SpeakerController(sessionService.Object);
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

            var resultModel = (IndexViewModel)_result.Model;
            Assert.NotNull(resultModel);
            Assert.False(string.IsNullOrWhiteSpace(resultModel.FirstName));
            Assert.True(resultModel.Id > 0);
        }
    }
}
