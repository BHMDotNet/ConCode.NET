using ConCode.NET.Core.Domain;
using ConCode.NET.Web.Models.SpeakerViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ConCode.NET.Web.Controllers
{
    public class SpeakerController : Controller
    {
        private ISpeakerService _speakerService;
        private IHttpContextAccessor _httpContextAccessor;

        public SpeakerController(IHttpContextAccessor httpContextAccessor, ISpeakerService service)
        {
            _speakerService = service;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var speakers = _speakerService.GetSpeakers();

            // Yes, Im randomly picking which speaker to show :)
            var random = new Random();
            var randomUserId = random.Next(1, speakers.Count() + 1);
            var speaker = speakers.FirstOrDefault(s => s.Id == randomUserId);

            // Create our ViewModel and fire up the View!
            var speakerViewModel = new SpeakerIndexViewModel(speaker);

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
            var speakerViewModel = new SpeakerEditViewModel(speaker);


            return View(speakerViewModel);
        }

        [HttpPost]
        public IActionResult Edit(SpeakerEditViewModel viewModel)
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
            return View(new SpeakerCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(SpeakerCreateViewModel viewModel)
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