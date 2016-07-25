using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ConCode.NET.Core.Domain;
using ConCode.NET.Web.Models.SessionViewModels;
using ConCode.NET.Core.Domain;

namespace ConCode.NET.Web.Controllers
{
    public class SessionController : Controller
    {
        private ISessionService sessionService;

        public SessionController(ISessionService service)
        {
            this.sessionService = service;
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
            var maxId = sessionService.GetSessions().Max(x => x.Id);
            // add the session to the sessionService
            var session = new Session
            {
                Id = maxId + 1,
                Start = model.Start,
                Talk = new Talk {
                    Id = model.TalkId,
                    Abstract = "Blah Blah",
                    Tags = new[] { "C#" , ".Net", "Asp.Net" },
                    Title = "Testing ASP.Net Core - Paradigm Shift"
                },
                TalkType = new TalkType {
                    Id = model.TalkTypeId
                },
                Venue = new Venue { Id = model.VenueId, Description = "Main Stage" }
            };

            sessionService.AddSession(session);

            return View("Index", new SessionListViewModel { SessionList = sessionService.GetSessions().ToList() });
        }
    }
}