using ConCode.NET.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

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