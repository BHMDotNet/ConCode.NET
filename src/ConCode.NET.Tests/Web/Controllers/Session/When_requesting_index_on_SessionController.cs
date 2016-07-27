using ConCode.NET.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using ConCode.NET.Core.Domain;
using ConCode.NET.Web.Models.SessionViewModels;
using Moq;

namespace ConCode.NET.Tests.Web.Controllers.Session
{
    public class When_requesting_index_on_SessionController
    {
        private ConCode.NET.Core.Domain.Session theSession;
        private IEnumerable<ConCode.NET.Core.Domain.Session> theSessionList;

        [Fact]
        public void Should_use_SessionService_to_fetch_list_of_sessions()
        {
            theSession = new ConCode.NET.Core.Domain.Session() {
                Id = 1,
                Start = DateTime.Now,
                Talk = new Talk(),
                TalkType = new TalkType(),
                Venue = new Venue()
            };

            theSessionList = new[]
            {
                theSession
            };

            var sessionService = new Mock<ISessionService>();
            var talkService = new Mock<ITalkService>();
            var venueService = new Mock<IVenueService>();
            var controller = new SessionController(sessionService.Object, talkService.Object, venueService.Object);
            sessionService.Setup(x => x.GetSessions()).Returns(theSessionList.AsQueryable());

            var result = (ViewResult)controller.Index();
            var model = (SessionListViewModel)result.Model;

            Assert.NotNull(model);
            Assert.Contains(theSession, model.SessionList);
        }
    }
}
