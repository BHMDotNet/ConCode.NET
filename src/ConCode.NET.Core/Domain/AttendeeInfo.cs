using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class AttendeeInfo
    {
        public long Id { get; set; }
        public bool IsAttending { get; set; }
        public long UserId { get; internal set; }
        public User User { get; internal set; }
    }
}
