using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public interface ISpeakerService
    {
        IQueryable<User> GetSpeakers();

        User GetSpeakerById(int userId);

        void SaveSpeaker(User speaker);

        void CreateSpeaker(User speaker);
    }
}
