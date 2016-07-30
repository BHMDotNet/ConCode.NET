using System.Collections.Generic;
using System.Linq;
using ConCode.NET.Core.Domain;
using System;
using Newtonsoft.Json;
using System.IO;

namespace ConCode.NET.Core.Data
{
    public class InMemoryConferenceDataProvider : IConferenceDataProvider
    {
        List<Talk> _talks;
        List<User> _speakers;
        List<User> _attendees;
        List<Session> _sessions;
        List<Sponsor> _sponsors;
        List<TalkType> _talkTypes;
        List<Venue> _venues;
        ConferenceInfo _conferenceInfo;

        private void LoadData<TypeOfData>(string typeOfData, Action<TypeOfData> action)
        {
            var data = JsonConvert.DeserializeObject<TypeOfData>(File.ReadAllText($"Data/Json/{typeOfData}.json"));
            action(data);
        }

        public InMemoryConferenceDataProvider()
        {
            LoadData<Talk[]>("Talks", d => _talks = new List<Talk>(d));
            LoadData<User[]>("Speakers", d => _speakers = new List<User>(d));
            LoadData<User[]>("Attendees", d => _attendees = new List<User>(d));
            LoadData<Sponsor[]>("Sponsors", d => _sponsors = new List<Sponsor>(d));
            LoadData<TalkType[]>("TalkTypes", d => _talkTypes = new List<TalkType>(d));
            LoadData<Venue[]>("Venues", d => _venues = new List<Venue>(d));
            LoadData<ConferenceInfo>("ConferenceInfo", d => _conferenceInfo = d);

            var statuses = new[] { SessionStatus.Open, SessionStatus.Postponed, SessionStatus.Full, SessionStatus.Finished, SessionStatus.Closed, SessionStatus.Cancelled };
            var levels = new[] { TalkLevel.Beginner, TalkLevel.Intermediate, TalkLevel.Advanced };

            var rnd = new Random();

            _sessions = new List<Session>();

            // lets create 20 sessions using a random talk, venue and speaker
            for (var index = 0; index < 20; index++)
            {
                var talk = _talks[rnd.Next(_talks.Count)];
                var speaker = _speakers[rnd.Next(_speakers.Count)];
                var venue = _venues[rnd.Next(_venues.Count)];
                var status = statuses[rnd.Next(statuses.Length)];
                var talkType = _talkTypes[rnd.Next(_talkTypes.Count)];

                speaker.SpeakerInfo.Talks = new List<Talk> { talk };
                talk.Speakers = new[] { speaker };
                talk.Level = levels[rnd.Next(levels.Length)];

                _sessions.Add(new Session
                {
                    Id = index,
                    Start = new DateTime(2016, 8, 10, rnd.Next(17), 0, 0),
                    Status = status,
                    Talk = talk,
                    TalkType = talkType,
                    Venue = venue
                });
            }
        }

      

        public IQueryable<Session> Sessions
        {
            get
            {
                return _sessions.AsQueryable();
            }
        }

        public IQueryable<User> GetSpeakers
        {
            get
            {
                return _speakers.AsQueryable();
            }
        }

        public IQueryable<Sponsor> GetSponsors
        {
            get
            {
                return _sponsors.AsQueryable();
            }
        }

        public IQueryable<Talk> GetTalks
        {
            get
            {
                return _talks.AsQueryable();
            }
        }

        public IEnumerable<TalkType> TalkTypes
        {
            get
            {
                return _talkTypes.AsQueryable();
            }
        }

        public IQueryable<Venue> Venues
        {
            get
            {
                //return _sessions.Select(x => x.Venue).AsQueryable();
                return _venues.AsQueryable();
            }
        }

        public IQueryable<User> GetAttendees
        {
            get
            {
                return _attendees.AsQueryable();
            }
        }

        public void AddVenue(Venue venue)
        {
            _venues = new List<Venue>(_venues) { venue };
        }

        public void AddSession(Session session)
        {
            _sessions = new List<Session>(_sessions) { session };
        }

        public void AddSponsor(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }

        public void SaveSpeaker()
        {
            throw new NotImplementedException();
        }

        public void AddSpeaker(User speaker)
        {
            throw new NotImplementedException();
        }

        public void SaveAttendee()
        {
            throw new NotImplementedException();
        }

        public ConferenceInfo ConferenceInfo
        {
            get
            {
                return _conferenceInfo;
            }
        }
    }
}
