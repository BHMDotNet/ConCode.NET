using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Web.Models.SpeakerViewModels
{
    public class SpeakerCreateViewModel
    {
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

        public string Tagline { get; set; }
    }
}
