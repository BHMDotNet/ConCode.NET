using CodeConf.NET.Core.Data;
using ConCode.NET.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CodeConf.NET.Tests.Core.Data
{
    // Not public so integration tests will be skipped. 
    class When_retrieving_users_from_the_database : IDisposable
    {
        private ConferenceDbContext _conferenceDbContext;
        private User _testUser;

        public When_retrieving_users_from_the_database()
        {
            var connectionOptions = new Moq.Mock<IOptions<ConnectionOption>>();
            _conferenceDbContext = new ConferenceDbContext(connectionOptions.Object);

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
