using ConCode.NET.Core;
using ConCode.NET.Core.Domain;
using ConCode.NET.Web.Controllers.Api;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ConCode.NET.Tests.Web.Controllers.Api.ConferenceInfoTest
{
    public class when_calling_the_conference_info_controller
    {
        [Fact]
        public void should_unit_the_conference_service_to_return_the_conference_data()
        {
            var theConferenceInfo = new ConferenceInfo();
            var conferenceService = new Mock<IConferenceService>();
            conferenceService.Setup(x => x.ConferenceInfo()).Returns(theConferenceInfo);
            var controller = new ConferenceController(conferenceService.Object);

            var result = controller.Get();
            Assert.IsType<ConferenceInfo>(result);
            Assert.Equal(result, theConferenceInfo);
        }
    }
}
