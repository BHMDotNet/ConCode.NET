using System;

namespace ConCode.NET.Domain
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
        public AttendeeInfo AttendeeInfo { get; set; }
    }
}
