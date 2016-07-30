using ConCode.NET.Core;
using ConCode.NET.Core.Data;

namespace ConCode.NET.Core.Domain
{
    public interface IConferenceService
    {
        ConferenceInfo ConferenceInfo();
    }

    public class ConferenceService : IConferenceService
    {
        IConferenceDataProvider dataProvider;

        public ConferenceService(IConferenceDataProvider dataProvider) 
        {
            this.dataProvider = dataProvider;
        }

        public ConferenceInfo ConferenceInfo()
        {
            return dataProvider.ConferenceInfo;
        }
    }
}