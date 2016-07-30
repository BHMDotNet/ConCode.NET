using ConCode.NET.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ConCode.NET.Web.Models.AttendeeViewModels
{
    public class AttendeeIndexViewModel
    {
        public AttendeeIndexViewModel()
        {
        }

        public AttendeeIndexViewModel(User model)
        {
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Username = model.Username;
            Bio = model.Bio;
            Photo = model.Photo;
            BlogUri = model.BlogUri;
            TwitterHandle = model.TwitterHandle;
            LinkedInProfile = model.LinkedInProfile;
            FacebookProfile = model.FacebookProfile;
        }

        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        public string Bio { get; set; }

        [Url]
        public string Photo { get; set; }

        [Url]
        public string BlogUri { get; set; }

        public string TwitterHandle { get; set; }

        public string LinkedInProfile { get; set; }

        public string FacebookProfile { get; set; }
        public string Greeting{get;set;}
    }
}
