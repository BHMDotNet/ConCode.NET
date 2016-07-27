using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ConCode.NET.Web.Models.SessionViewModels
{
    public class AddSessionViewModel
    {

        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        [Display(Name = "Session Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Session Time")]
        public int StartTime { get; set; }

        [Display(Name = "Talk")]
        public int TalkId { get; set; }

        [Display(Name = "Talk Type")]
        public int TalkTypeId { get; set; }

    }
}
