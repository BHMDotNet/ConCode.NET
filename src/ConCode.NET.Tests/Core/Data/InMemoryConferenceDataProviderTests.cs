using ConCode.NET.Core.Data;
using ConCode.NET.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
