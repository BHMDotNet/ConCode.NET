namespace ConCode.NET.Domain
{
    public class AttendeeInfo
    {
        public long Id { get; set; }
        public bool IsAttending { get; set; }
        public long UserId { get; internal set; }
        public User User { get; internal set; }
    }
}
