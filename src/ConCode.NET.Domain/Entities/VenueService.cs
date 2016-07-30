using ConCode.NET.Domain.Interfaces;
using System.Linq;

namespace ConCode.NET.Domain
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

        public Venue GetVenue(int venueId)
        {
            return _conferenceDataProvider.Venues.FirstOrDefault(x => x.Id == venueId);
        }
    }
}
