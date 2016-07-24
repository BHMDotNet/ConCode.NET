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
            }
        };

        public IQueryable<Session> Sessions
        {
            get
            {
                return _sessions.AsQueryable();
            }
        }
    }
}
