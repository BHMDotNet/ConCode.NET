using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public interface ISponsorService
    {
        IQueryable<Sponsor> GetSponsors();

        void AddSponsor(Sponsor sponsor);
    }
}
