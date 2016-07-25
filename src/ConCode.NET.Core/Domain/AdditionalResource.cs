using System;

namespace ConCode.NET.Core.Domain
{
    public class AdditionalResource
    {
        public string Name { get; set; }
        public Uri Uri { get; set; }

        public ResourceType Type { get; set; }
    }
}