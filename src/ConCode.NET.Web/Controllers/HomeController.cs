using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConCode.NET.Core.Domain;
using ConCode.NET.Web.Models.ViewModels;

namespace ConCode.NET.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Session List
        public IActionResult SessionList()
        {
            ViewData["Message"] = "This is the session list";
            //All of this is just placeholder code. Feel free to remove it when
            //you do the actual implementation.
            var sessionList = new List<Session>();

            var session = new Session{
                Start = DateTime.Now.AddDays(100),
                TalkType = new TalkType(){
                    Name = "Lightning",
                    Length = new TimeSpan(0,30,0) 
                },
                Venue = new Venue{
                    Description = "Room 201"
                },
                Talk = new Talk {
                    Title = "Deep Dive into Workflow Foundation",
                    Abstract = "I recommend you don't fire until you're within 40,000 kilometers. About four years. I got tired of hearing how young I looked. Now we know what they mean by 'advanced' tactical training. Maybe if we felt any human loss as keenly as we feel one of those close to us, human history would be far less bloody. We know you're dealing in stolen ore. But I wanna talk about the assassination attempt on Lieutenant Worf.",
                    Level = TalkLevel.Advanced,
                    TimesPresented = 5
                    }
            };
            sessionList.Add(session);
            
            var model = new SessionListViewModel{
                SessionList = sessionList
            };

            return View(model);
        }
        #endregion

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
