using ConCode.NET.Core.Data;
using ConCode.NET.Core.Domain;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConCode.NET.Tests.Core.Domain
{
    public class When_executing_VenueService
    {
        private Mock<IConferenceDataProvider> _mockConferenceDataProvider;
        private IVenueService _venueService;
        private IQueryable<Venue> _venues;

        public When_executing_VenueService()
        {
            _mockConferenceDataProvider = new Mock<IConferenceDataProvider>();
            _mockConferenceDataProvider.Setup(d => d.Venues).Returns(new List<Venue>
            {
                new Venue { Id = 1, Description = "Room 201" }

            }.AsQueryable());

            _venueService = new VenueService(_mockConferenceDataProvider.Object);
        }

        [Fact]
        public void Should_return_venues()
        {
            _venues = _venueService.GetVenues();

            _mockConferenceDataProvider.Verify(x => x.Venues);
            Assert.NotEmpty(_venues);
            Assert.Equal(_venues.FirstOrDefault().Description, "Room 201");           
        }
    }
}
