using ConCode.NET.Core.Domain;
using ConCode.NET.Web.Models.SpeakerViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ConCode.NET.Web.Controllers
{
    public class SpeakerController : Controller
    {
        public static Speaker CreateSpeakerPocoTemplate()
        {
            return new Speaker
            {
                Id = 1,
                Bio = "I recommend you don't fire until you're within 40,000 kilometers. About four years. I got tired of hearing how young I looked. Now we know what they mean by 'advanced' tactical training. Maybe if we felt any human loss as keenly as we feel one of those close to us, human history would be far less bloody. We know you're dealing in stolen ore. But I wanna talk about the assassination attempt on Lieutenant Worf.",
                BlogUri = "http://theverybestblog.com",
                CreatedAt = DateTime.Now,
                FacebookProfile = "blakehelms",
                FirstName = "Blake",
                LastName = "Helms",
                ModifiedAt = DateTime.Now,
                LinkedInProfile = "blakehelms",
                Photo = "https://pbs.twimg.com/profile_images/287277250/WebReadyColorProfilePhoto.jpg",
                Tagline = "Someone very interesting",
                TwitterHandle = "helmsb",
                //Talks = new List<Talk>()
                //{
                //    new Talk
                //    {
                //        Title = "The Color Tuple",
                //        Abstract = "Fate protects fools, little children and ships named Enterprise. I guess it's better to be lucky than good. Why don't we just give everybody a promotion and call it a night - 'Commander'?",
                //        Level = TalkLevel.Intermediate,
                //        TimesPresented = 1,
                //        Tags = new List<string>{
                //            "C# 7",
                //            ".NET"
                //        }
                //    },
                //    new Talk
                //    {
                //        Title = "Asyncronous In A Syncronous World",
                //        Abstract = "Well, that's certainly good to know. The Enterprise computer system is controlled by three primary main processor cores, cross-linked with a redundant melacortz ramistat, fourteen kiloquad interface modules.",
                //        Level = TalkLevel.Advanced,
                //        TimesPresented = 4,
                //        Tags = new List<string>{
                //            "Async",
                //            "C#",
                //            ".NET"
                //        }
                //    }
                //}
            };
        }

        private ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService service)
        {
            _speakerService = service;
        }

        public IActionResult Index()
        {
            var speakers = _speakerService.GetSpeakers();

            // Yes, Im randomly picking which speaker to show :)
            var random = new Random();
            var randomUserId = random.Next(1, speakers.Count() + 1);
            var speaker = speakers.FirstOrDefault(s => s.Id == randomUserId);

            // Create our ViewModel and fire up the View!
            var speakerViewModel = new IndexViewModel(speaker);

            return View(speakerViewModel);
        }
    }
}