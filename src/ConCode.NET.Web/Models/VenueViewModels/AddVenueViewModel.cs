using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConCode.NET.Web.Models.VenueViewModels
{
    public class AddVenueViewModel
    {
        [Required]
        public string Description { get; set; }
    }
}
