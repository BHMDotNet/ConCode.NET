using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConCode.NET.Core.Domain;

namespace CodeConf.NET.Core.Domain
{
    public class SessionService : ISessionService
    {
        public IQueryable<Session> GetSessions()
        {
            throw new NotImplementedException();
        }
    }
}
