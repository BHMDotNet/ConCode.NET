using ConCode.NET.Core.Domain.Interfaces;
using ConCode.NET.Web.Models.AttendeeViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ConCode.NET.Web.Controllers
{
    public class AttendeeController : Controller
    {

        private IAttendeeService _attendeeService;

        public AttendeeController(IAttendeeService service)
        {
            _attendeeService = service;
        }

        public IActionResult Index()
        {
            var attendees = _attendeeService.GetAttendees();

            // Yes, Im randomly picking which speaker to show :)
            var random = new Random();
            var randomUserId = random.Next(1001, 1000 + attendees.Count() + 1);
            var attendee = attendees.FirstOrDefault(s => s.Id == randomUserId);

            // Create our ViewModel and fire up the View!
            var attendeeViewModel = new IndexViewModel(attendee);

            return View(attendeeViewModel);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var attendees = _attendeeService.GetAttendees();

            // Yes, Im randomly picking which speaker to show :)
            var random = new Random();
            var randomUserId = random.Next(1001, 1000 + attendees.Count() + 1);
            var attendee = attendees.FirstOrDefault(s => s.Id == randomUserId);

            // Create our ViewModel and fire up the View!
            var attendeeViewModel = new EditViewModel(attendee);

            return View(attendeeViewModel);
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
            var attendee = _attendeeService.GetAttendees().FirstOrDefault(s => s.Id == viewModel.Id);
            if (attendee == null)
            {
                ModelState.AddModelError(string.Empty, "Error locating your Attendee profile from the database.");
                return View(viewModel);
            }

            // Append on top the changes
            attendee.FirstName = viewModel.FirstName;
            attendee.LastName = viewModel.LastName;
            attendee.Username = viewModel.Username;
            attendee.Bio = viewModel.Bio;
            attendee.Photo = viewModel.Photo;
            attendee.BlogUri = viewModel.BlogUri;
            attendee.TwitterHandle = viewModel.TwitterHandle;
            attendee.LinkedInProfile = viewModel.LinkedInProfile;
            attendee.FacebookProfile = viewModel.FacebookProfile;
            attendee.ModifiedAt = DateTime.Now;

            // Actually save this model data!
            _attendeeService.SaveAttendee(attendee);

            // Redirect back to Index()
            return RedirectToAction("Index");
        }
    }
}