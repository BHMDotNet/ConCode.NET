using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public interface ISpeakerService
    {
        IQueryable<User> GetSpeakers();

        User GetSpeakerById(int userId);

        User GetSpeakerByUsername(string username);

        void SaveSpeaker();

        void CreateSpeaker(User speaker);
    }
}
