using ConCode.NET.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ConCode.NET.Core.Data
{
    public interface IConferenceDataProvider
    {
        IQueryable<Session> Sessions { get; }

        void AddSession(Session session);

        IQueryable<Speaker> Speakers { get; }

        IQueryable<Talk> Talks { get; }

        IQueryable<Venue> Venues { get; }

        void AddVenue(Venue venue);

        IEnumerable<TalkType> TalkTypes { get; }

        IQueryable<Sponsor> Sponsors { get; }

        void AddSponsor(Sponsor sponsor);

        void SaveSpeaker(Speaker speaker);

        void AddSpeaker(Speaker speaker);

        IQueryable<Attendee> Attendees { get; }

        void SaveAttendee(Attendee attendee);
    }
}
