using ConCode.NET.Core.Domain.Interfaces;
using ConCode.NET.Web.Controllers;
using ConCode.NET.Web.Models.AttendeeViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;
using AttendeePoco = ConCode.NET.Core.Domain.Attendee;

namespace ConCode.NET.Tests.Web.Controllers.Attendee
{
    public class When_requesting_Index_on_AttendeeController
    {
        private AttendeeController _controller;
        private ViewResult _result;

        public When_requesting_Index_on_AttendeeController()
        {
            var theAttendee = new AttendeePoco
            {
                Id = 1001,
                FirstName = "Brandon"
            };

            var theAttendeeList = new[]
            {
                theAttendee
            };

            var service = new Moq.Mock<IAttendeeService>();
            service.Setup(x => x.GetAttendees()).Returns(theAttendeeList.AsQueryable());

            _controller = new AttendeeController(service.Object);
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
