using System;

namespace ConCode.NET.Core.Domain
{
    public class Resource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }

        public ResourceType Type { get; set; }
        
    }
}