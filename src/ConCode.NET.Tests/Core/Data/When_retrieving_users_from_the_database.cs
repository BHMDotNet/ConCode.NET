using CodeConf.NET.Core.Data;
using ConCode.NET.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ConCode.NET.Tests;

namespace CodeConf.NET.Tests.Core.Data
{
    // Not public so db integration tests will be skipped. 
    class When_retrieving_users_from_the_database : IDisposable
    {
        private ConferenceDbContext _conferenceDbContext;
        private User _testUser;
        private Mock<IOptions<ConnectionOption>> _mockConnectionOption;

        public When_retrieving_users_from_the_database()
        {
            _mockConnectionOption = new Moq.Mock<IOptions<ConnectionOption>>();
            ConnectionOption connectionOption = new ConnectionOption
            {
                ConCode = ConCodeConfiguration.Config["ConnectionStrings:ConCode"]
            };
            _mockConnectionOption.SetupGet(x => x.Value).Returns(connectionOption);
            _conferenceDbContext = new ConferenceDbContext(_mockConnectionOption.Object);

            _testUser = new User {
                FirstName = "Luke",
                LastName = "Skywalker",
                Username = "lskywalker",
                ModifiedBy = "unit test",
                SpeakerInfo = new SpeakerInfo { Tagline = "You're not my father!"}
            };
            _conferenceDbContext.Users.Add(_testUser);
            _conferenceDbContext.SaveChanges();

        }
        
        [Fact]
        public void Should_create_user()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.NotNull(user);
        }
        [Fact]
        public void Should_get_speaker_info_on_user()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.Equal(_testUser.SpeakerInfo.Tagline, user.SpeakerInfo.Tagline);
        }
        [Fact]
        public void Should_get_user()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");

            Assert.Same(_testUser, user);
        }
        [Fact]
        public void Should_delete_user()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            _conferenceDbContext.Users.Remove(user);
            _conferenceDbContext.SaveChanges();
            user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.Null(user);
        }
        [Fact]
        public void Should_save_attendee_info()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            user.AttendeeInfo = new AttendeeInfo { };
            _conferenceDbContext.SaveChanges();
            user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.NotNull(user.AttendeeInfo);
        }
        [Fact]
        public void Should_save_attendee_is_attending()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            user.AttendeeInfo = new AttendeeInfo { IsAttending = true };
            _conferenceDbContext.SaveChanges();
            user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.Equal(true, user.AttendeeInfo.IsAttending);
        }
        [Fact]
        public void Should_save_speaker_talk()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            user.SpeakerInfo = new SpeakerInfo { Talks = new List<Talk> { new Talk { Title = "How to find your father" } } };
            _conferenceDbContext.SaveChanges();
            user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.NotNull(user.SpeakerInfo);
        }
        [Fact]
        public void Should_save_talk_resources()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            //user.SpeakerInfo = new SpeakerInfo { };
            _conferenceDbContext.SaveChanges();
            user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.NotNull(user.SpeakerInfo);
        }

        public void Dispose()
        {
            var user = _conferenceDbContext.Users.FirstOrDefault(x => x.FirstName == "Luke");
            if (user != null){
                _conferenceDbContext.Users.Remove(user);
                _conferenceDbContext.SaveChanges();
            }
        }
    }
}
