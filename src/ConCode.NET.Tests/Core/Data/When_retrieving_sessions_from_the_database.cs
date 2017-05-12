using ConCode.NET.Core.Data;
using ConCode.NET.Domain;
using ConCode.NET.Tests;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodeConf.NET.Tests.Core.Data
{
    // Not public so db integration tests will be skipped. 
    class When_retrieving_sessions_from_the_database : IDisposable
    {
        private ConferenceDbContext _conferenceDbContext;
        private User _testSpeaker;
        private Mock<IOptions<ConnectionOption>> _mockConnectionOption;
        private Session _testSession;
        private List<TalkType> _testTalkTypes;

        public When_retrieving_sessions_from_the_database()
        {
            _mockConnectionOption = new Moq.Mock<IOptions<ConnectionOption>>();
            ConnectionOption connectionOption = new ConnectionOption
            {
                ConCode = ConCodeConfiguration.Config["ConnectionStrings:ConCode"]
            };
            _mockConnectionOption.SetupGet(x => x.Value).Returns(connectionOption);
            _conferenceDbContext = new ConferenceDbContext(_mockConnectionOption.Object);

            _testSpeaker = new User
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                Username = "lskywalker",
                ModifiedBy = "unit test",
                SpeakerInfo = new SpeakerInfo
                {
                    Tagline = "You're not my father!",
                    Talks = new List<Talk> { new Talk {
                        Title = "How to find your father"
            } }
                }
            };
            _conferenceDbContext.Users.Add(_testSpeaker);
            _testTalkTypes = new List<TalkType>
            {
                new TalkType { Name = "Standard", Length = TimeSpan.FromMinutes(75) },
                new TalkType { Name = "Lightening", Length = TimeSpan.FromMinutes(15) },
            };
            _conferenceDbContext.SaveChanges();

            _testSession = new Session
            {
                Talk = _testSpeaker.SpeakerInfo.Talks.First(),
                Start = new DateTime(2016, 08, 20),
                Status = SessionStatus.Full,
                TalkType = _testTalkTypes.Last()
            };
            _conferenceDbContext.Sessions.Add(_testSession);
            _conferenceDbContext.SaveChanges();
        }
        [Fact]
        public void Should_return_session()
        {
            var session = _conferenceDbContext.Sessions.First();
            Assert.NotNull(session);
        }

        public void Dispose()
        {
            var session = _conferenceDbContext.Sessions.FirstOrDefault(x => x.Start == new DateTime(2016, 08, 20));
            if (session != null)
            {
                _conferenceDbContext.Sessions.Remove(session);
            }
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            if (user != null)
            {
                _conferenceDbContext.Users.Remove(user);
                _conferenceDbContext.SaveChanges();
            } 
        }
    }
}
