using ConCode.NET.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ConCode.NET.Core.Data
{
    public interface IConferenceDataProvider
    {
        ConferenceInfo ConferenceInfo { get; }

        #region Session
        IQueryable<Session> Sessions { get; }

        void AddSession(Session session);
        #endregion

        #region Venue
        IQueryable<Venue> Venues { get; }

        void AddVenue(Venue venue);
        #endregion

        #region Talk
        IEnumerable<TalkType> TalkTypes { get; }

        IQueryable<Talk> GetTalks { get; }
        #endregion

        #region Sponser
        IQueryable<Sponsor> GetSponsors { get; }

        void AddSponsor(Sponsor sponsor);
        #endregion

        #region Speaker
        IQueryable<User> GetSpeakers { get; }

        void SaveSpeaker();

        void AddSpeaker(User speaker);
        #endregion

        #region Attendees
        IQueryable<User> GetAttendees { get; }

        void SaveAttendee();
        #endregion
    }
}
