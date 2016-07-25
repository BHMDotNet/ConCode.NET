using System.Collections.Generic;
using System.Linq;
using ConCode.NET.Core.Domain;
using System;

namespace ConCode.NET.Core.Data
{
    public class InMemoryConferenceDataProvider : IConferenceDataProvider
    {
        private IEnumerable<Session> _sessions = new List<Session>()
        {
            new Session
            {
                Id = 1,
                Start = new System.DateTime(2016, 8, 4),
                Talk = new Talk
                    {
                        Title = "The Color Tuple",
                        Abstract = "Fate protects fools, little children and ships named Enterprise. I guess it's better to be lucky than good. Why don't we just give everybody a promotion and call it a night - 'Commander'?",
                        Level = TalkLevel.Intermediate,
                        TimesPresented = 1,
                        Tags = new List<string>{
                            "C# 7",
                            ".NET"
                        }
                    },
                TalkType = new TalkType()
                {
                    Id = 1,
                    Length = TimeSpan.FromMinutes(60),
                    Name = "Deep Dive"
                },
                Venue = new Venue()
                {
                    Id = 1,
                    Description = "Main Stage"
                }
            },

            new Session
            {
                Id = 1,
                Start = new DateTime(2016, 8, 4),
                Talk = new Talk
                    {
                        Title = "Deep Dive Into Workflow Foundation",
                        Abstract = "I recommend you don't fire until you're within 40,000 kilometers. About four years. I got tired of hearing how young I looked. Now we know what they mean by 'advanced' tactical training. Maybe if we felt any human loss as keenly as we feel one of those close to us, human history would be far less bloody. We know you're dealing in stolen ore. But I wanna talk about the assassination attempt on Lieutenant Worf.",
                        Level = TalkLevel.Advanced,
                        TimesPresented = 27,
                        Tags = new List<string>{
                            "C# 7",
                            ".NET",
                            "Workflow"
                        }
                    },
                TalkType = new TalkType()
                {
                    Id = 2,
                    Length = TimeSpan.FromMinutes(30),
                    Name = "Lightning"
                },
                Venue = new Venue()
                {
                    Id = 2,
                    Description = "Room 201"
                }
            }
        };


        private IEnumerable<Venue> _venues = new List<Venue>()
        {
            new Venue
            {
                Id = 1,
                Description = "Room 201"
            },
            new Venue
            {
                Id = 2,
                Description = "Room 202"
            },
            new Venue
            {
                Id = 3,
                Description = "Room 203"
            },
             new Venue
            {
                Id = 4,
                Description = "Room 204"
            },
              new Venue
            {
                Id = 5,
                Description = "Room 205"
            }

        };

        public IQueryable<Session> Sessions
        {
            get
            {
                return _sessions.AsQueryable();
            }
        }

        public IQueryable<Speaker> Speakers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Talk> Talks
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<TalkType> TalkTypes
        {
            get
            {
                throw new NotImplementedException();
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

        public void AddVenue(Venue venue)
        {
            _venues = new List<Venue>(_venues) { venue };
        }

        public void AddSession(Session session)
        {
            _sessions = new List<Session>(_sessions) { session };
        }
    }
}
