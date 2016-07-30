namespace ConCode.NET.Domain
{
    public class Resource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }

        public ResourceType Type { get; set; }
        
    }
}