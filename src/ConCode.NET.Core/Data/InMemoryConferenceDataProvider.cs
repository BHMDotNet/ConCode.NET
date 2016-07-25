using System.Collections.Generic;
using System.Linq;
using ConCode.NET.Core.Domain;
using System;

namespace ConCode.NET.Core.Data
{
    public class InMemoryConferenceDataProvider : IConferenceDataProvider
    {
        #region Sessions
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
                        Speakers = new List<Speaker>{
                            new Speaker{ 
                                Id = 1,
                                Bio = "I recommend you don't fire until you're within 40,000 kilometers. About four years. I got tired of hearing how young I looked. Now we know what they mean by 'advanced' tactical training. Maybe if we felt any human loss as keenly as we feel one of those close to us, human history would be far less bloody. We know you're dealing in stolen ore. But I wanna talk about the assassination attempt on Lieutenant Worf.",
                                BlogUri = new Uri("http://theverybestblog.com"),
                                CreatedAt = DateTime.Now,
                                FacebookProfile = "blakehelms",
                                FirstName = "Blake",
                                LastName = "Helms",
                                LastUpdated = DateTime.Now,
                                LinkedInProfile = "blakehelms",
                                Photo = new Uri("https://pbs.twimg.com/profile_images/287277250/WebReadyColorProfilePhoto.jpg"),
                                Tagline = "Someone very interesting",
                                TwitterHandle = "helmsb"
                            }
                        },
                        Tags = new List<string>{
                            "C# 7",
                            ".NET"
                        },
                        AdditionalResources = new List<AdditionalResource>{
                            new AdditionalResource{
                                Name = "Handout",
                                Type = ResourceType.PDF,
                                Uri = new Uri("https://www.bu.edu/clarion/guides/Star_Trek_Writers_Guide.pdf")
                            },
                            new AdditionalResource{
                                Name = "Slide Deck",
                                Type = ResourceType.PPT,
                                Uri = new Uri("https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=13&ved=0ahUKEwi7uLDKhY3OAhXBQSYKHSD3DpY4ChAWCCcwAg&url=http%3A%2F%2Fwww.damiantgordon.com%2FCourses%2FOperatingSystems1%2FDemos%2FF-OS1-LCARS.pptx&usg=AFQjCNFr1Zu_eoCHZDHn97dD8NXDPBwRBg&sig2=DRzOLEK-_pGqSs8Vl4ntnQ&bvm=bv.127984354,d.eWE")
                            }
                            
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
                },
                Status = SessionStatus.Full
            },

            new Session
            {
                Id = 2,
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
                        },
                        Speakers = new List<Speaker>{
                            new Speaker{ 
                                FirstName = "Blake",
                                LastName = "Helms"
                            }
                        },
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
                },
                Status = SessionStatus.Open
            }
        };
        #endregion

        #region Speakers Data
        private IEnumerable<Speaker> _speakers = new List<Speaker>()
        {
            new Speaker{
                Id = 1,
                Bio = "I recommend you don't fire until you're within 40,000 kilometers. About four years. I got tired of hearing how young I looked. Now we know what they mean by 'advanced' tactical training. Maybe if we felt any human loss as keenly as we feel one of those close to us, human history would be far less bloody. We know you're dealing in stolen ore. But I wanna talk about the assassination attempt on Lieutenant Worf.",
                BlogUri = new Uri("http://theverybestblog.com"),
                CreatedAt = DateTime.Now,
                FacebookProfile = "blakehelms",
                FirstName = "Blake",
                LastName = "Helms",
                LastUpdated = DateTime.Now,
                LinkedInProfile = "blakehelms",
                Photo = new Uri("https://pbs.twimg.com/profile_images/287277250/WebReadyColorProfilePhoto.jpg"),
                Tagline = "Someone very interesting",
                TwitterHandle = "helmsb"
            },
            new Speaker{
                Id = 2,
                Bio = "I collect spores, molds, and fungus.",
                BlogUri = new Uri("http://theverybestblog.com"),
                CreatedAt = DateTime.Now,
                FacebookProfile = "blrussell",
                FirstName = "Brandon",
                LastName = "Russell",
                LastUpdated = DateTime.Now,
                LinkedInProfile = "toocoolforschool",
                Photo = new Uri("http://photos1.meetupstatic.com/photos/member/c/8/6/0/member_257331296.jpeg"),
                Tagline = "We're ready to believe you!",
                TwitterHandle = "brussellz"
            }
        };
        #endregion

        #region Talk Data
        IEnumerable<Talk> _talks = new List<Talk>()
        {
            new Talk
            {
                Title = "The Color Tuple",
                Abstract = "Fate protects fools, little children and ships named Enterprise. I guess it's better to be lucky than good. Why don't we just give everybody a promotion and call it a night - 'Commander'?",
                Level = TalkLevel.Intermediate,
                TimesPresented = 1,
                Speakers = new List<Speaker>(),
                Tags = new List<string>{
                            "C# 7",
                            ".NET"
                        },
                AdditionalResources = new List<AdditionalResource>{
                            new AdditionalResource{
                                Name = "Handout",
                                Type = ResourceType.PDF,
                                Uri = new Uri("https://www.bu.edu/clarion/guides/Star_Trek_Writers_Guide.pdf")
                            },
                            new AdditionalResource{
                                Name = "Slide Deck",
                                Type = ResourceType.PPT,
                                Uri = new Uri("https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=13&ved=0ahUKEwi7uLDKhY3OAhXBQSYKHSD3DpY4ChAWCCcwAg&url=http%3A%2F%2Fwww.damiantgordon.com%2FCourses%2FOperatingSystems1%2FDemos%2FF-OS1-LCARS.pptx&usg=AFQjCNFr1Zu_eoCHZDHn97dD8NXDPBwRBg&sig2=DRzOLEK-_pGqSs8Vl4ntnQ&bvm=bv.127984354,d.eWE")
                            }

                        }
            },
            new Talk
            {
                Title = "Deep Dive Into Workflow Foundation",
                Abstract = "I recommend you don't fire until you're within 40,000 kilometers. About four years. I got tired of hearing how young I looked. Now we know what they mean by 'advanced' tactical training. Maybe if we felt any human loss as keenly as we feel one of those close to us, human history would be far less bloody. We know you're dealing in stolen ore. But I wanna talk about the assassination attempt on Lieutenant Worf.",
                Level = TalkLevel.Advanced,
                TimesPresented = 27,
                Tags = new List<string>{
                    "C# 7",
                    ".NET",
                    "Workflow"
                },
                Speakers = new List<Speaker>(),
            }
        };
        #endregion

        public InMemoryConferenceDataProvider()
        {
            // Set up some existing speakers to the talks
            int i = 0;
            foreach (var talk in _talks)
            {
                i++;
                var speaker = _speakers.DefaultIfEmpty(_speakers.First()).FirstOrDefault(s => s.Id == i);
                if (speaker == null)
                {
                    speaker = _speakers.First();
                }

                talk.Speakers = new List<Speaker>() { speaker };

                // Also appead this talk to the speakers talk list
                if (speaker.Talks != null)
                {
                    speaker.Talks = new List<Talk>(speaker.Talks) { talk };
                }
                else
                {
                    speaker.Talks = new List<Talk> { talk };
                }
            }
        }

        private IEnumerable<Sponsor> _sponsors = new List<Sponsor>
        {
            new Sponsor
            {
                Id = 1,
                ImageUrl = new Uri("http://moviesmedia.ign.com/movies/image/article/115/1157513/initech_1301965579.jpg"),
                Name = "Initech",
                SponsorshipLevel = SponsorshipLevel.bronze,
                WebsiteUrl = new Uri("http://www.initech.com")
            },

            new Sponsor
            {
                Id = 2,
                ImageUrl = new Uri("http://ih1.redbubble.net/image.55130916.7058/ap,550x550,16x12,1,transparent,t.png"),
                Name = "Dunder Mifflin, Inc.",
                SponsorshipLevel = SponsorshipLevel.silver,
                WebsiteUrl = new Uri("http://www.dundermifflin.com")
            },

            new Sponsor
            {
                Id = 3,
                ImageUrl = new Uri("http://static.squarespace.com/static/531f2c4ee4b002f5b011bf00/t/536bdcefe4b03580f8f6bb16/1399577848961/hbosiliconvalleypiedpiperoldlogo"),
                Name = "Pied Piper",
                SponsorshipLevel = SponsorshipLevel.platinum,
                WebsiteUrl = new Uri("http://www.piedpiper.com")
            },
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
                return _speakers.AsQueryable();
            }
        }

        public IQueryable<Sponsor> Sponsors
        {
            get
            {
                return _sponsors.AsQueryable();
            }
        }

        public IQueryable<Talk> Talks
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

        public void AddSponsor(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }
    }
}
