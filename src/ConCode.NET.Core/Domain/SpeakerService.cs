using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConCode.NET.Core.Domain;
using CodeConf.NET.Core.Data;

namespace CodeConf.NET.Core.Domain
{
    public class SpeakerService : ISpeakerService
    {
        private IConferenceDataProvider _conferenceDataProvider;

        public SpeakerService(IConferenceDataProvider conferenceDataProvider)
        {
            _conferenceDataProvider = conferenceDataProvider;
        }

        public IQueryable<Speaker> GetSpeakers()
        {
            return _conferenceDataProvider.Speakers;
        }
    }
}
