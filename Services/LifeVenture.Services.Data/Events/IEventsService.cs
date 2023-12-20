namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEventsService
    {
        Task<IEnumerable<T>> GetAll<T>();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllCategories();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllPhoneCodes();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegions();
    }
}
