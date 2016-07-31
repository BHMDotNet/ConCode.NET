using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConCode.NET.Web.Models.TalkViewModels;
using ConCode.NET.Domain.Interfaces;

namespace ConCode.NET.Web.Controllers
{
    public class TalkController : Controller
    {
        private ITalkService talkService;
        private ISpeakerService speakerService;

        public TalkController(ITalkService talkService)
        {
            this.talkService = talkService;
        }

        public IActionResult Submit()
        {
            return View(new SubmitTalkViewModel());
        }

        [HttpPost]
        public IActionResult Submit(SubmitTalkViewModel model)
        {
            talkService.AddTalk(new Domain.Talk
            {
                Title = model.Title,
                Level = model.Level,
                Tags = model.TagList,
                TimesPresented = model.TimesPresented,
                Abstract = model.Abstract
            });
            
            return View("TalkSubmitted", new TalkSubmittedViewModel { Title = model.Title });
        }
    }
}
