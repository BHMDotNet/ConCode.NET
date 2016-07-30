using ConCode.NET.Core.Domain

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