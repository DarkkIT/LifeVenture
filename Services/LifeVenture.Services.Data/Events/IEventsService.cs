namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Home;
    using LifeVenture.Web.ViewModels.Image;

    public interface IEventsService
    {
        Task CreateEvent(CreateEventInputModel input, string userId);

        Task<IEnumerable<T>> GetAll<T>();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllCategories();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllPhoneCodes();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegions();

        Task<EventStatisticalInfoViewModel> GetEventStatistics();
    }
}
