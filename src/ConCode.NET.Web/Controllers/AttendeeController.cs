using ConCode.NET.Domain;
using ConCode.NET.Domain.Interfaces;
using ConCode.NET.Web.Models.AttendeeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace ConCode.NET.Web.Controllers
{
    public class AttendeeController : Controller
    {

        private IHttpContextAccessor _httpContextAccessor;
        private IAttendeeService _attendeeService;

        public AttendeeController(IHttpContextAccessor httpContextAccessor, IAttendeeService service)
        {
            _attendeeService = service;
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
            return _attendeeService.GetAttendeeByUsername(username);
        }
        #endregion

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var attendee = GetLoggedInUser();

            // Sanity check
            if (attendee == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            // Create our ViewModel and fire up the View!
            var attendeeViewModel = new AttendeeIndexViewModel(attendee);
            attendeeViewModel.Greeting = GreetingRandomizer(); 
            
            return View(attendeeViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            var attendee = GetLoggedInUser();

            // Sanity check
            if (attendee == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            // Create our ViewModel and fire up the View!
            var attendeeViewModel = new AttendeeEditViewModel(attendee);
            attendeeViewModel.Greeting = GreetingRandomizer(); 

            return View(attendeeViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(AttendeeEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Something wasn't valid, send them back
                return View(viewModel);
            }

            // Rehydrate the model object and then append on top our changes
            var attendee = GetLoggedInUser();

            // Sanity check
            if (attendee == null)
            {
                ModelState.AddModelError(string.Empty, "Error locating your Attendee profile from the database.");
                return View(viewModel);
            }

            // Append on top the changes
            attendee.FirstName = viewModel.FirstName;
            attendee.LastName = viewModel.LastName;
            attendee.Username = GetUsername();
            attendee.Bio = viewModel.Bio;
            attendee.Photo = viewModel.Photo;
            attendee.BlogUri = viewModel.BlogUri;
            attendee.TwitterHandle = viewModel.TwitterHandle;
            attendee.LinkedInProfile = viewModel.LinkedInProfile;
            attendee.FacebookProfile = viewModel.FacebookProfile;

            // Actually save this model data!
            _attendeeService.SaveAttendee();

            // Redirect back to Index()
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Serves no purpose other than increasing system whimsy
        /// </summary>
        /// <returns></returns>
        private string GreetingRandomizer()
        {
            var names = new List<string> { "Greetings", "Hello", "Hi", "Howdy", "Hey","What's up", "Hi-ya","Aloha", "nuqneH", "Welcome" };
            var random = new System.Random();
            int index = random.Next(names.Count);
            var name = names[index];
            
            return name;
        }
    }
}