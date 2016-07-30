using System.Linq;

namespace ConCode.NET.Domain.Interfaces
{
    public interface ISponsorService
    {
        IQueryable<Sponsor> GetSponsors();

        void AddSponsor(Sponsor sponsor);
    }
}
