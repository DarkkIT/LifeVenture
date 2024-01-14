namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LifeVenture.Data.Common.Repositories;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class EventsService : IEventsService
    {
        private readonly IDeletableEntityRepository<Event> eventsRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<CountryPhoneCode> countryPhoneCodesRepository;

        public EventsService(
            IDeletableEntityRepository<Event> eventsRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IRepository<CountryPhoneCode> countryPhoneCodesRepository)
        {
            this.eventsRepository = eventsRepository;
            this.categoriesRepository = categoriesRepository;
            this.countryPhoneCodesRepository = countryPhoneCodesRepository;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
            => await this.eventsRepository
            .All()
            .To<T>()
            .ToListAsync();

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllCategories()
        {
            var categories = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("0", "ИЗБЕРИ"),
            };

            var categoriesFromDb = await this.categoriesRepository
                .All()
                .Select(c => new KeyValuePair<string, string>(c.Id.ToString(), c.Name))
                .ToListAsync();

            categories.AddRange(categoriesFromDb);
            return categories;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllPhoneCodes()
        {
            var phoneCodes = this.GetDefaultOption();

            var phoneCodesFromDb = await this.countryPhoneCodesRepository
                .All()
                .Select(c => new KeyValuePair<string, string>(c.Id.ToString(), $"{c.Code} {c.Country}"))
                .ToListAsync();

            phoneCodes.AddRange(phoneCodesFromDb);
            return phoneCodes;
        }

        private List<KeyValuePair<string, string>> GetDefaultOption()
            => new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("0", "ИЗБЕРИ"),
            };
    }
}
