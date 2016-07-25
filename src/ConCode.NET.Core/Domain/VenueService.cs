using System.Linq;
using ConCode.NET.Core.Data;

namespace ConCode.NET.Core.Domain
{
    public class VenueService : IVenueService
    {
        private IConferenceDataProvider _conferenceDataProvider;

        public VenueService(IConferenceDataProvider conferenceDataProvider)
        {
            _conferenceDataProvider = conferenceDataProvider;
        }

        public void AddVenue(Venue venue)
        {
            _conferenceDataProvider.AddVenue(venue);
        }

        public IQueryable<Venue> GetVenues()
        {
            return _conferenceDataProvider.Venues;
        }
    }
}
