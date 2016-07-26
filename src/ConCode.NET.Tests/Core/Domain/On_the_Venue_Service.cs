using Moq;
using System.Linq;
using Xunit;
using ConCode.NET.Core.Domain;
using ConCode.NET.Core.Data;

namespace ConCode.NET.Tests.Core.Domain
{
    public class On_the_Venue_Service 
    {

        [Fact]
        public void Should_use_the_IConferenceDataProvider_when_calling_GetVenues()
        {
            var venue = new Venue { Id = 1, Description = "Room 201" };            
               
            var venueList = new[] { venue };
            var confDataProvider = new Mock<IConferenceDataProvider>();
            confDataProvider.Setup(x => x.Venues).Returns(venueList.AsQueryable);
            var venueService = new VenueService(confDataProvider.Object);
            var venues = venueService.GetVenues();

            Assert.NotNull(venues);
            Assert.Equal(venue.Description, "Room 201");
            Assert.Contains(venue, venues);
        }
    }
}
