using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public interface IVenueService
    {
        IQueryable<Venue> GetVenues();

        void AddVenue(Venue venue);

        Venue GetVenue(int VenueId);
    }
}
