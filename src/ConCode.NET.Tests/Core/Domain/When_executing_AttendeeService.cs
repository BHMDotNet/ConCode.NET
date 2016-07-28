using ConCode.NET.Core.Data;
using ConCode.NET.Core.Domain;
using ConCode.NET.Core.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConCode.NET.Tests.Core.Domain
{
    public class When_executing_AttendeeService
    {
        private Mock<IConferenceDataProvider> _mockConferenceDataProvider;
        private IAttendeeService _attendeeService;
        private IQueryable<Attendee> _attendees;

        public When_executing_AttendeeService()
        {
            _mockConferenceDataProvider = new Mock<IConferenceDataProvider>();
            _mockConferenceDataProvider.Setup(d => d.Attendees).Returns(new List<Attendee> { new Attendee() }.AsQueryable());

            _attendeeService = new AttendeeService(_mockConferenceDataProvider.Object);
        }

        [Fact]
        public void Should_return_attendees()
        {
            _attendees = _attendeeService.GetAttendees();

            _mockConferenceDataProvider.Verify(x => x.Attendees);
            Assert.NotEmpty(_attendees);
        }
    }
}
