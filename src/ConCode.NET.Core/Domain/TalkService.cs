using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConCode.NET.Core.Domain;
using CodeConf.NET.Core.Data;

namespace CodeConf.NET.Core.Domain
{
    public class TalkService : ITalkService
    {
        private IConferenceDataProvider _conferenceDataProvider;

        public TalkService(IConferenceDataProvider conferenceDataProvider)
        {
            _conferenceDataProvider = conferenceDataProvider;
        }

        public IQueryable<Talk> GetTalks()
        {
            return _conferenceDataProvider.Talks;
        }
    }
}
