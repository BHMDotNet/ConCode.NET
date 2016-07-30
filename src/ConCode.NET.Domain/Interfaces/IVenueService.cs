using System.Linq;

namespace ConCode.NET.Domain.Interfaces
{
    public interface IVenueService
    {
        IQueryable<Venue> GetVenues();

        void AddVenue(Venue venue);

        Venue GetVenue(int VenueId);
    }
}
