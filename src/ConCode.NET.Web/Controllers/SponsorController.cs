using Microsoft.AspNetCore.Mvc;
using ConCode.NET.Web.Models.SponsorViewModels;
using ConCode.NET.Core.Domain;

namespace ConCode.NET.Web.Controllers
{
    public class SponsorController : Controller
    {
        private ISponsorService sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            this.sponsorService = sponsorService;
        }
    }
}