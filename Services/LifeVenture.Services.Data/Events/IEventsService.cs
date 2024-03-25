namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LifeVenture.Web.ViewModels.Common;
    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Home;

    public interface IEventsService
    {
        Task<bool> CreateEvent(CreateEventInputModel input, string userId);

        Task<PaginatedList<T>> GetAll<T>(int page, int itemsPerPage, EventsFiltersInputViewModel filters);

        Task<int> GetEventsCount(int? categoryId = null);

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllCategories();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllPhoneCodes();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegions();

        Task<List<HomeEventViewModel>> GetEventsForHomePage();

        Task<EventStatisticalInfoViewModel> GetEventStatistics();

        Task<T> GetEventById<T>(int id);

        Task AddViewsCount(int id);

        Task<CreateEventViewModel> GetEventData();
    }
}
