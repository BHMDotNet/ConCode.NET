using System.Linq;

namespace ConCode.NET.Domain.Interfaces
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
