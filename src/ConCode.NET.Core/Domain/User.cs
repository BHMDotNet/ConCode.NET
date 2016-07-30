using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Core.Domain
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public string BlogUri { get; set; }
        public string TwitterHandle { get; set; }
        public string LinkedInProfile { get; set; }
        public string FacebookProfile { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public SpeakerInfo SpeakerInfo { get; set; }
    }
}
