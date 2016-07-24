using ConCode.NET.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ConCode.NET.Web.Controllers
{
    public class SpeakerController : Controller
    {
        public static Speaker CreateSpeakerPocoTemplate()
        {
            return new Speaker
            {
                Id = 1,
                Bio = "A very interesting story needs supplying here.",
                BlogUri = new Uri("http://theverybestblog.com"),
                CreatedAt = DateTime.Now,
                FacebookProfile = string.Empty,
                FirstName = "John",
                LastName = "Doe",
                LastUpdated = DateTime.Now,
                LinkedInProfile = string.Empty,
                Photo = null,
                Tagline = "Someone very interesting",
                TwitterHandle = string.Empty,
                Talks = new List<Talk>()
                {
                    new Talk
                    {
                        Title = "The Color Tuple",
                        Abstract = "Everyone needs a helping hand with Tuples.",
                        Level = TalkLevel.Intermediate,
                        TimesPresented = 1
                    },
                    new Talk
                    {
                        Title = "Asyncronous In A Syncronous World",
                        Abstract = "How to break through the bonds of syncronous operations.",
                        Level = TalkLevel.Advanced,
                        TimesPresented = 4
                    }
                }
            };
        }

        public IActionResult Index()
        {
            //TODO: Need to get the Speaker object from somewhere right?
            var speaker = CreateSpeakerPocoTemplate();

            return View(speaker);
        }
    }
}