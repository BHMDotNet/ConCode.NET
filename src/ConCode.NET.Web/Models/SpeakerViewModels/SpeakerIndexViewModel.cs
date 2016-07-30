using ConCode.NET.Core.Domain;
using System;
using System.Collections.Generic;

namespace ConCode.NET.Web.Models.SpeakerViewModels
{
    public class SpeakerIndexViewModel
    {
        private User _speaker;

        public SpeakerIndexViewModel(User speaker)
        {
            _speaker = speaker;
        }

        public long Id
        {
            get { return _speaker.Id; }
        }

        public string FirstName
        {
            get { return _speaker.FirstName; }
        }

        public string LastName
        {
            get { return _speaker.LastName; }
        }

        public string Photo
        {
            get { return _speaker.Photo; }
        }

        public string Tagline
        {
            get { return _speaker.SpeakerInfo.Tagline; }
        }

        public string Bio
        {
            get { return _speaker.Bio; }
        }

        public string TwitterHandle
        {
            get { return _speaker.TwitterHandle; }
        }

        public string LinkedInProfile
        {
            get { return _speaker.LinkedInProfile; }
        }

        public string FacebookProfile
        {
            get { return _speaker.FacebookProfile; }
        }

        public string BlogUri
        {
            get { return _speaker.BlogUri; }
        }

        public IEnumerable<Talk> Talks
        {
            get { return _speaker.SpeakerInfo.Talks; }
        }
    }
}
