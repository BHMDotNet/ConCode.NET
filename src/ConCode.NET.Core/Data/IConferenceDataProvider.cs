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

        IEnumerable<TalkType> TalkTypes { get; }

        IQueryable<Sponsor> Sponsors { get; }

        void AddSponsor(Sponsor sponsor);
    }
}
