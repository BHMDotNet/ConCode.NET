using System;

namespace ConCode.NET.Web.Models.SessionViewModels
{
    public class AddSessionViewModel
    {
        public int TalkId { get; set; }
        public int VenueId { get; set; }
        public int TalkTypeId { get; set; }
        public DateTime Start { get; set; }
    }
}
