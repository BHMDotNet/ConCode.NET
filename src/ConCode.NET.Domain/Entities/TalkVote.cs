namespace ConCode.NET.Domain
{
    public class TalkVote
    {
        public Talk Talk { get; set; }
        public User User { get; set; }
        public bool? Liked { get; set; }
        public string Comment { get; set; }
    }
}
