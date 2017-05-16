using ConCode.NET.Domain;
using ConCode.NET.Domain.Interfaces;
using ConCode.NET.Web.Models.SpeakerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

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

        #region Method(s)
        /// <summary>
        /// Quick way to get the username of the currently logged in user.
        /// </summary>
        /// <returns>Username</returns>
        public string GetUsername()
        {
            // Sanity check
            if (_httpContextAccessor == null || 
                _httpContextAccessor.HttpContext == null || 
                _httpContextAccessor.HttpContext.User == null)
            {
                return string.Empty;
            }

            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        }

        /// <summary>
        /// Return the User domain object based off the currently logged in user.
        /// </summary>
        /// <returns>User domain object</returns>
        public User GetLoggedInUser()
        {
            var username = GetUsername();
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            // Obtain the speaker from the DataAccess service
            return _speakerService.GetSpeakerByUsername(username);
        }
        #endregion

        #region Action(s)
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var speaker = GetLoggedInUser();
            
            // Sanity check
            if (speaker == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            // Create our ViewModel and fire up the View!
            var speakerViewModel = new SpeakerIndexViewModel(speaker);

            return View(speakerViewModel);
        }


        [HttpGet]
        public IActionResult GetSpeakers()
        {
            var speakerListViewModel = new SpeakerListViewModel { SpeakerList = _speakerService.GetSpeakers().ToList() };

            return View(speakerListViewModel);
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {  
            var speaker = _speakerService.GetSpeakerById(Id);
            return View("Details", new SpeakerDetailsViewModel { speakerInfo = speaker });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            var speaker = GetLoggedInUser();

            // Sanity check
            if (speaker == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            // Create our ViewModel and fire up the View!
            var speakerViewModel = new SpeakerEditViewModel(speaker);


            return View(speakerViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(SpeakerEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Something wasn't valid, send them back
                return View(viewModel);
            }

            // Rehydrate the model object and then append on top our changes
            var speaker = GetLoggedInUser();

            // Sanity check
            if (speaker == null)
            {
                ModelState.AddModelError(string.Empty, "Error locating your Speaker profile from the database.");
                return View(viewModel);
            }

            // Append on top the changes
            speaker.FirstName = viewModel.FirstName;
            speaker.LastName = viewModel.LastName;
            speaker.Username = GetUsername();
            speaker.Bio = viewModel.Bio;
            speaker.Photo = viewModel.Photo;
            speaker.BlogUri = viewModel.BlogUri;
            speaker.TwitterHandle = viewModel.TwitterHandle;
            speaker.LinkedInProfile = viewModel.LinkedInProfile;
            speaker.FacebookProfile = viewModel.FacebookProfile;
            speaker.SpeakerInfo.Tagline = viewModel.Tagline;

            // Actually save this model data!
            _speakerService.SaveSpeaker();

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
            speaker.Username = GetUsername();
            speaker.Bio = viewModel.Bio;
            speaker.Photo = viewModel.Photo;
            speaker.BlogUri = viewModel.BlogUri;
            speaker.TwitterHandle = viewModel.TwitterHandle;
            speaker.LinkedInProfile = viewModel.LinkedInProfile;
            speaker.FacebookProfile = viewModel.FacebookProfile;
            speaker.SpeakerInfo = new SpeakerInfo { Tagline = viewModel.Tagline };

            // Actually save this model data!
            _speakerService.CreateSpeaker(speaker);

            // Redirect back to Index()
            return RedirectToAction("Index");
        }
        #endregion
    }
}