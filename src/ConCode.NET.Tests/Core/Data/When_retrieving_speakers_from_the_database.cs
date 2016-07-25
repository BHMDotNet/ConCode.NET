using CodeConf.NET.Core.Data;
using ConCode.NET.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CodeConf.NET.Tests.Core.Data
{
    // Not public so integration tests will be skipped. 
    class When_retrieving_speakers_from_the_database : IDisposable
    {
        private ConferenceDbContext _conferenceDbContext;
        private Speaker _testSpeaker;

        public When_retrieving_speakers_from_the_database()
        {
            _conferenceDbContext = new ConferenceDbContext();

            _testSpeaker = new Speaker {
                FirstName = "Luke",
                LastName = "Skywalker",
                Username = "lskywalker",
                ModifiedBy = "unit test"
            };
            _conferenceDbContext.Speakers.Add(_testSpeaker);
            _conferenceDbContext.SaveChanges();

        }
        
        [Fact]
        public void Should_create_speaker()
        {
            var speaker = _conferenceDbContext.Speakers.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.NotNull(speaker);
        }
        [Fact]
        public void Should_get_speaker()
        {
            var speaker = _conferenceDbContext.Speakers.FirstOrDefault(x => x.FirstName == "Luke");

            Assert.Same(_testSpeaker, speaker);
        }
        [Fact]
        public void Should_delete_speaker()
        {
            var speaker = _conferenceDbContext.Speakers.FirstOrDefault(x => x.FirstName == "Luke");
            _conferenceDbContext.Speakers.Remove(speaker);
            _conferenceDbContext.SaveChanges();
            speaker = _conferenceDbContext.Speakers.FirstOrDefault(x => x.FirstName == "Luke");
            Assert.Null(speaker);
        }

        public void Dispose()
        {
            var speaker = _conferenceDbContext.Speakers.FirstOrDefault(x => x.FirstName == "Luke");
            if (speaker != null){
                _conferenceDbContext.Speakers.Remove(speaker);
                _conferenceDbContext.SaveChanges();
            }
        }
    }
}
