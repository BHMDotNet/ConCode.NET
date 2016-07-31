using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConCode.NET.Web.Models.TalkViewModels;

namespace ConCode.NET.Web.Controllers
{
    public class TalkController : Controller
    {
        public IActionResult Submit()
        {
            return View(new SubmitTalkViewModel());
        }
    }
}
