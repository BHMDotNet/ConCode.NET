using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public interface ISpeakerService
    {
        IQueryable<User> GetSpeakers();

        void SaveSpeaker(User speaker);

        void CreateSpeaker(User speaker);
    }
}
