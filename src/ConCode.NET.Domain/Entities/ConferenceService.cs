using ConCode.NET.Domain.Interfaces;

namespace ConCode.NET.Domain
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