using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ConCode.NET.Web.Models.SessionViewModels;
using ConCode.NET.Core.Domain;

namespace ConCode.NET.Web.Controllers
{
    public class SessionController : Controller
    {
        private ISessionService sessionService;
        private ITalkService talkService;
        private IVenueService venueService;

        public SessionController(ISessionService sessionService, ITalkService talkService, IVenueService venueService)
        {
            this.sessionService = sessionService;
            this.talkService = talkService;
            this.venueService = venueService;
        }

        public IActionResult Index()
        {
            var model = new SessionListViewModel { SessionList = sessionService.GetSessions().ToList() };
            return View(model);
        }

        public IActionResult Details(int Id)
        {
            var session = sessionService.GetSessions().FirstOrDefault(x => x.Id == Id);
            return View("details", new SessionDetailsViewModel { Session = session });
        }

        public IActionResult Add()
        {
            return View(new AddSessionViewModel());
        }


        [HttpPost]
        public IActionResult Add(AddSessionViewModel model)
        {
            var talk = talkService.GetTalk(model.TalkId);
            var venue = venueService.GetVenue(model.VenueId);
            var session = new Session 
            {
                Talk = talk,
                Start = model.StartDate.AddHours(model.StartTime),
                Venue = venue,
                TalkType = talkService.GetTalkType(model.TalkTypeId),
                Status = SessionStatus.Open
            };

            sessionService.AddSession(session);

            return View("Index", new SessionListViewModel { SessionList = sessionService.GetSessions().ToList() });
        }
    }
}
