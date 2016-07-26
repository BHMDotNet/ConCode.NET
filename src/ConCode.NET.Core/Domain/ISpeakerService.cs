using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public interface ISpeakerService
    {
        IQueryable<Speaker> GetSpeakers();

        void SaveSpeaker(Speaker speaker);

        void CreateSpeaker(Speaker speaker);
    }
}
