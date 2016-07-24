using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public enum SessionStatus
    {
        Open,
        Closed,
        Finished,
        Postponed,
        Cancelled,
        Full
    }
}
