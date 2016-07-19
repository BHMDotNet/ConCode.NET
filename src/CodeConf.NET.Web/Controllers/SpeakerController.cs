using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeConf.NET.Web.Controllers
{
    public class SpeakerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}