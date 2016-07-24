using ConCode.NET.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeConf.NET.Core.Data
{
    public interface IConferenceDataProvider
    {
        IQueryable<Session> Sessions { get; }

        void AddSession(Session session);

        IQueryable<Speaker> Speakers { get; }

        IQueryable<Talk> Talks { get; }

        IQueryable<Venue> Venues { get; }

        IEnumerable<TalkType> TalkTypes { get; }
    }
}
