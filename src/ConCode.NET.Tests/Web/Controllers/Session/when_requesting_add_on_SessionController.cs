using ConCode.NET.Domain;
using ConCode.NET.Domain.Interfaces;
using ConCode.NET.Web.Controllers;
using ConCode.NET.Web.Models.SessionViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace ConCode.NET.Tests.Web.Controllers.Session
{
    public class when_requesting_add_on_SessionController
    {
        [Fact]
        public void should_return_a_view_with_an_AddSessionViewModel()
        {
            var sessionService = new Mock<ISessionService>();
            var talkService = new Mock<ITalkService>();
            var venueService = new Mock<IVenueService>();
            var controller = new SessionController(sessionService.Object, talkService.Object, venueService.Object);

            var result = controller.Add();

            Assert.NotNull(result);
            Assert.IsType<AddSessionViewModel>(((ViewResult)result).Model);
        }

        [Fact]
        public void should_add_a_session_when_posting_to_add_action()
        {
            var theTalkId = 5;
            var theTalk = new Talk();

            var theVenueId = 9;
            var theVenue = new Venue();

            var talkService = new Mock<ITalkService>();
            talkService.Setup(x => x.GetTalk(theTalkId)).Returns(theTalk);

            var venueService = new Mock<IVenueService>();
            venueService.Setup(x => x.GetVenue(theVenueId)).Returns(theVenue);

            var sessionService = new Mock<ISessionService>();
            

            var model = new AddSessionViewModel
            {
                TalkId = theTalkId,
                VenueId = theVenueId,
                StartDate = DateTime.Now,
                StartTime = 6,
            };

            var sessionController = new SessionController(sessionService.Object, talkService.Object, venueService.Object);

            var result = sessionController.Add(model);

            Assert.IsType<SessionListViewModel>(((ViewResult)result).Model);
        }
    }
}
