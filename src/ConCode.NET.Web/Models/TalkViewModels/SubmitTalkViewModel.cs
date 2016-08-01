using ConCode.NET.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ConCode.NET.Web.Models.TalkViewModels
{
    public class SubmitTalkViewModel
    {
        public string Title { get; set; }

        public string Abstract { get; set; }

        public TalkLevel Level { get; set; }

        public IEnumerable<SelectListItem> TalkLevels
        {
            get
            {
                return new[] {
                    new SelectListItem { Value = ((int)TalkLevel.Beginner).ToString(), Text = TalkLevel.Beginner.ToString() },
                    new SelectListItem { Value = ((int)TalkLevel.Intermediate).ToString(), Text = TalkLevel.Intermediate.ToString() },
                    new SelectListItem { Value = ((int)TalkLevel.Advanced).ToString(), Text = TalkLevel.Advanced.ToString() }
                };
            }
        }

        public IEnumerable<string> TagList { get; set; }

        public int TimesPresented { get; set; }
    }
}
