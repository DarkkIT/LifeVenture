namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Home;

    public interface IEventsService
    {
        Task CreateEvent(CreateEventInputModel input, string userId);

        Task<IEnumerable<T>> GetAll<T>(int page, int itemsPerPage);

        Task<int> GetEventsCount();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllCategories();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllPhoneCodes();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegions();

        Task<List<HomeEventViewModel>> GetEventsForHomePage();

        Task<EventStatisticalInfoViewModel> GetEventStatistics();
    }
}
