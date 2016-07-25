using System.Collections.Generic;
using System.Linq;
using ConCode.NET.Core.Domain;
using System;

namespace CodeConf.NET.Core.Data
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
                throw new NotImplementedException();
            }
        }

        public void AddSession(Session session)
        {
            _sessions = new List<Session>(_sessions) { session };
        }
    }
}
