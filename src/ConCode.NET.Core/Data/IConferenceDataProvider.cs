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
    }
}
