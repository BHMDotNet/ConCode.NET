using ConCode.NET.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ConCode.NET.Core.Data
{
    public interface IConferenceDataProvider
    {
        ConferenceInfo ConferenceInfo { get; }
        
        IQueryable<Session> Sessions { get; }

        void AddSession(Session session);

        IQueryable<User> GetSpeakers { get; }

        IQueryable<Talk> GetTalks { get; }

        IQueryable<Venue> Venues { get; }

        void AddVenue(Venue venue);

        IEnumerable<TalkType> TalkTypes { get; }

        IQueryable<Sponsor> Sponsors { get; }

        void AddSponsor(Sponsor sponsor);

        void SaveSpeaker();

        void AddSpeaker(User speaker);

        IQueryable<User> Attendees { get; }

        void SaveAttendee(User attendee);
    }
}
