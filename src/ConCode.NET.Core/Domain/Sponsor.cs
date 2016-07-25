using System;
namespace ConCode.NET.Core.Domain
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri WebsiteUrl { get; set; }
        public SponsorshipLevel SponsorshipLevel { get; set; }
        public Uri ImageUrl { get; set; }
    }
}
