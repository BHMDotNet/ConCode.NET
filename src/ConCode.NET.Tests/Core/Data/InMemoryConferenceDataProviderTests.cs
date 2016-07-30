using ConCode.NET.Core.Data;
using ConCode.NET.Domain;
using System.Linq;
using Xunit;

namespace ConCode.NET.Tests.Core.Data
{
    public class InMemoryConferenceDataProviderTest
    {
        [Fact]
        public void adding_session_should_be_added_to_the_in_memory_list()
        {
            var theSession = new Session();

            var provider = new InMemoryConferenceDataProvider();
            var priorCount = provider.Sessions.Count();

            provider.AddSession(theSession);

            Assert.Equal(priorCount + 1, provider.Sessions.Count());
        }
    }
}
