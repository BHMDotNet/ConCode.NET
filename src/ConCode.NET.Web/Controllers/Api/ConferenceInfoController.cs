using ConCode.NET.Core;
using ConCode.NET.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ConCode.NET.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Conference")]
    public class ConferenceController : Controller
    {
        private IConferenceService conferenceService;

        [HttpGet]
        public ConferenceInfo Get()
        {
            return conferenceService.ConferenceInfo();
        }

        
    }
}