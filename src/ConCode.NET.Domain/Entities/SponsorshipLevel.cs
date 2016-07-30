namespace ConCode.NET.Domain
{
    public class SponsorshipLevel
    {
        public string Description { get; }
        public decimal SponsoredAmount { get; }

        public SponsorshipLevel(string description, decimal sponsoredAmount)
        {
            Description = description;
            SponsoredAmount = sponsoredAmount;
        }

        public static SponsorshipLevel bronze = new SponsorshipLevel("Bronze", 100m);
        public static SponsorshipLevel silver = new SponsorshipLevel("Silver", 500m);
        public static SponsorshipLevel gold = new SponsorshipLevel("Gold", 1000m);
        public static SponsorshipLevel platinum = new SponsorshipLevel("Platinum", 5000m);
    }
}
