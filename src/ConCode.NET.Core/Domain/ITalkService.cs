using System.Linq;

namespace ConCode.NET.Core.Domain
{
    public interface ITalkService
    {
        IQueryable<Talk> GetTalks();
    }
}
