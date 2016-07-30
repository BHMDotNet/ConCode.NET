using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class AttendeeInfo
    {
        public int Id { get; set; }
        public bool IsAttending { get; set; }
        public int UserId { get; internal set; }
        public User User { get; internal set; }
    }
}
