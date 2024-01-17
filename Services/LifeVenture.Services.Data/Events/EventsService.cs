namespace LifeVenture.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LifeVenture.Data.Common.Repositories;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Events;
    using Microsoft.EntityFrameworkCore;

    public class EventsService : IEventsService
    {
        private readonly IDeletableEntityRepository<Event> eventsRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<CountryPhoneCode> countryPhoneCodesRepository;
        private readonly IDeletableEntityRepository<Region> regionsRepository;

        public EventsService(
            IDeletableEntityRepository<Event> eventsRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IRepository<CountryPhoneCode> countryPhoneCodesRepository,
            IDeletableEntityRepository<Region> regionsRepository)
        {
            this.eventsRepository = eventsRepository;
            this.categoriesRepository = categoriesRepository;
            this.countryPhoneCodesRepository = countryPhoneCodesRepository;
            this.regionsRepository = regionsRepository;
        }

        public async Task CreateEvent(CreateEventViewModel input)
        {
            var eventModel = new Event
            {
                CategoryId = input.CategoryId,
                CreatedById = " ",
                Description = input.Description,
                Email = input.Email,
                EndDate = input.EndDate,
                StartDate = input.StartDate,
                IsApproved = true,
                IsInDrafts = false,
                Phone = new Phone { Number = input.Phone.Number, CodeId = input.Phone.CodeId },
                IsUrgent = input.IsUrgent,
                Title = input.Title,
            };

            foreach (var location in input.Locations)
            {
                var modelLocation = new Location
                {
                    MunicipalityId = location.MunicipalityId,
                    SettlementId = location.SettlementId,
                    RegionId = location.RegionId,
                };

                eventModel.Locations.Add(modelLocation);
            }

            await this.eventsRepository.AddAsync(eventModel);
            await this.eventsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll<T>()
            => await this.eventsRepository
            .All()
            .To<T>()
            .ToListAsync();

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllCategories()
        {
            var defaultCategory = this.GetDefaultOption();

            var categories = await this.categoriesRepository
                .All()
                .OrderBy(c => c.Id)
                .Select(c => new KeyValuePair<string, string>(c.Id.ToString(), c.Name))
                .ToListAsync();

            categories.Insert(0, defaultCategory);

            return categories;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllPhoneCodes()
            => await this.countryPhoneCodesRepository
                .All()
                .OrderByDescending(c => c.IsDefault)
                .ThenBy(c => c.Id)
                .Select(c => new KeyValuePair<string, string>(c.Id.ToString(), $"{c.Country} {c.Code}"))
                .ToListAsync();

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegions()
        {
            var defaultOption = this.GetDefaultOption();
            var regions = await this.regionsRepository
                .All()
                .OrderBy(r => r.Name)
                .Select(r => new KeyValuePair<string, string>(r.Id.ToString(), $"{r.Name}"))
                .ToListAsync();

            regions.Insert(0, defaultOption);

            return regions;
        }

        private KeyValuePair<string, string> GetDefaultOption()
            => new KeyValuePair<string, string>("0", "ИЗБЕРИ");
    }
}
