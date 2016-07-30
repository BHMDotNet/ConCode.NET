using ConCode.NET.Core.Data;
using System.Linq;

namespace ConCode.NET.Core.Domain
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
