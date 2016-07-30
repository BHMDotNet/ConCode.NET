using ConCode.NET.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ConCode.NET.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Conference")]
    public class ConferenceController : Controller
    {
        private IConferenceService conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        [HttpGet]
        public ConferenceInfo Get()
        {
            return conferenceService.ConferenceInfo();
        }

        
    }
}