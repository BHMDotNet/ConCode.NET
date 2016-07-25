using ConCode.NET.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeConf.NET.Core.Domain
{
    public interface ITalkService
    {
        IQueryable<Talk> GetTalks();
    }
}
