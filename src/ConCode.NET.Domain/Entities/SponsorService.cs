using ConCode.NET.Domain.Interfaces;
using System.Linq;

namespace ConCode.NET.Domain
{
    public class SponsorService : ISponsorService
    {
        private IConferenceDataProvider dataProvider;

        public SponsorService(IConferenceDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public void AddSponsor(Sponsor sponsor)
        {
            dataProvider.AddSponsor(sponsor);
        }

        public IQueryable<Sponsor> GetSponsors()
        {
            return dataProvider.GetSponsors;
        }
    }
}
