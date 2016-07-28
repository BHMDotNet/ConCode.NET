using ConCode.NET.Core.Domain;
using ConCode.NET.Web.Models.SpeakerViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ConCode.NET.Web.Controllers
{
    public class SpeakerController : Controller
    {
        public static User CreateSpeakerPocoTemplate()
        {
            return new User
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
                TwitterHandle = "helmsb",
                SpeakerInfo = new SpeakerInfo { Tagline = "Someone very interesting" }
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

        [HttpGet]
        public IActionResult Edit()
        {
            //TODO: Need some way of knowing the current caller's UserType and be able to
            //grab the speaker from the collection based on some stored value in the user session?
            var speakers = _speakerService.GetSpeakers();

            // Yes, Im randomly picking which speaker to show :)
            var random = new Random();
            var randomUserId = random.Next(1, speakers.Count() + 1);
            var speaker = speakers.FirstOrDefault(s => s.Id == randomUserId);

            // Create our ViewModel and fire up the View!
            var speakerViewModel = new EditViewModel(speaker);

            return View(speakerViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Something wasn't valid, send them back
                return View(viewModel);
            }

            // Rehydrate the model object and then append on top our changes
            var speaker = _speakerService.GetSpeakers().FirstOrDefault(s => s.Id == viewModel.Id);
            if (speaker == null)
            {
                ModelState.AddModelError(string.Empty, "Error locating your Speaker profile from the database.");
                return View(viewModel);
            }

            // Append on top the changes
            speaker.FirstName = viewModel.FirstName;
            speaker.LastName = viewModel.LastName;
            speaker.Username = viewModel.Username;
            speaker.Bio = viewModel.Bio;
            speaker.Photo = viewModel.Photo;
            speaker.BlogUri = viewModel.BlogUri;
            speaker.TwitterHandle = viewModel.TwitterHandle;
            speaker.LinkedInProfile = viewModel.LinkedInProfile;
            speaker.FacebookProfile = viewModel.FacebookProfile;
            speaker.SpeakerInfo.Tagline = viewModel.Tagline;
            speaker.ModifiedAt = DateTime.Now;

            // Actually save this model data!
            _speakerService.SaveSpeaker(speaker);

            // Redirect back to Index()
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Something wasn't valid, send them back
                return View(viewModel);
            }

            var speaker = new User();

            // Append on top the changes
            speaker.FirstName = viewModel.FirstName;
            speaker.LastName = viewModel.LastName;
            speaker.Username = viewModel.Username;
            speaker.Bio = viewModel.Bio;
            speaker.Photo = viewModel.Photo;
            speaker.BlogUri = viewModel.BlogUri;
            speaker.TwitterHandle = viewModel.TwitterHandle;
            speaker.LinkedInProfile = viewModel.LinkedInProfile;
            speaker.FacebookProfile = viewModel.FacebookProfile;
            speaker.SpeakerInfo = new SpeakerInfo { Tagline = viewModel.Tagline };
            speaker.CreatedAt = DateTime.Now;
            speaker.ModifiedAt = speaker.CreatedAt;

            // Actually save this model data!
            _speakerService.CreateSpeaker(speaker);

            // Redirect back to Index()
            return RedirectToAction("Index");
        }
    }
}