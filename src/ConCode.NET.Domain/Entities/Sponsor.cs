namespace ConCode.NET.Domain
{
    public class Sponsor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public SponsorshipLevel SponsorshipLevel { get; set; }
        public string ImageUrl { get; set; }
    }
}
