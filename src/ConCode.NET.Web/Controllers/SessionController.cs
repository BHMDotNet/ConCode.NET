using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ConCode.NET.Web.Models.ViewModels;
using CodeConf.NET.Core.Domain;

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
    }
}