namespace ConCode.NET.Domain
{
    public class TalkResource
    {
        public long TalkId { get; set; }
        public Talk Talk { get; set; }
        public long ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}
