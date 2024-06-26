﻿namespace LifeVenture.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LifeVenture.Data.Common.Repositories;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Common;
    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Home;
    using Microsoft.EntityFrameworkCore;

    public class EventsService : IEventsService
    {
        private readonly IDeletableEntityRepository<Event> eventsRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<CountryPhoneCode> countryPhoneCodesRepository;
        private readonly IDeletableEntityRepository<Region> regionsRepository;
        private readonly IDeletableEntityRepository<Municipality> municipalitiesRepository;
        private readonly IDeletableEntityRepository<Settlement> settlementsRepository;
        private readonly IImageService imageService;

        public EventsService(
            IDeletableEntityRepository<Event> eventsRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IRepository<CountryPhoneCode> countryPhoneCodesRepository,
            IDeletableEntityRepository<Region> regionsRepository,
            IDeletableEntityRepository<Municipality> municipalitiesRepository,
            IDeletableEntityRepository<Settlement> settlementsRepository,
            IImageService imageService)
        {
            this.eventsRepository = eventsRepository;
            this.categoriesRepository = categoriesRepository;
            this.countryPhoneCodesRepository = countryPhoneCodesRepository;
            this.regionsRepository = regionsRepository;
            this.municipalitiesRepository = municipalitiesRepository;
            this.settlementsRepository = settlementsRepository;
            this.imageService = imageService;
        }

        public async Task<bool> CreateEvent(CreateEventInputModel input, string userId)
        {
            var eventModel = new Event
            {
                CategoryId = input.CategoryId,
                CreatedById = userId,
                Description = input.Description,
                Email = input.Email,
                EndDate = input.EndDate,
                StartDate = input.StartDate,
                IsApproved = true,
                IsInDrafts = false,
                Phone = new Phone { Number = input.Phone.Number, CodeId = input.Phone.CodeId },
                IsUrgent = input.IsUrgent,
                Title = input.Title,
                MaxParticipantsCount = input.MaxParticipantsCount,
            };

            var modelLocation = new Location
            {
                MunicipalityId = input.Location.MunicipalityId,
                SettlementId = input.Location.SettlementId,
                RegionId = input.Location.RegionId,
            };

            eventModel.Location = modelLocation;

            var imageModel = await this.imageService.GetImageData(input.Image);

            if (imageModel == null)
            {
                return false;
            }
            else
            {
                eventModel.Image = imageModel;
            }

            await this.eventsRepository.AddAsync(eventModel);
            await this.eventsRepository.SaveChangesAsync();

            return true;
        }

        public async Task<PaginatedList<T>> GetAll<T>(int page, int itemsPerPage, EventsFiltersInputViewModel filters)
        {
            var query = this.eventsRepository
                .All()
                .Where(e => e.EndDate > DateTime.UtcNow);

            if (filters?.CategoryId != null && filters?.CategoryId != 0)
            {
                query = query
                    .Where(e => e.CategoryId == filters.CategoryId);
            }
            else if (filters?.Latest == true)
            {
                query = query
                    .OrderByDescending(e => e.CreatedOn);
            }
            else if (filters?.MostPopular == true)
            {
                query = query
                    .OrderByDescending(e => e.UserLikes.Count);
            }
            else if (filters?.MostVisited == true)
            {
                query = query
                    .OrderByDescending(e => e.ViewsCount);
            }

            var count = await query.CountAsync();
            var items = await query
                .To<T>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            var paginatedList = new PaginatedList<T>(items, count, page, itemsPerPage);

            return paginatedList;
        }

        public async Task<int> GetEventsCount(int? categoryId = 0)
        {
            var query = this.eventsRepository
                .All();

            if (categoryId.HasValue && categoryId != 0)
            {
                query = query
                    .Where(e => e.CategoryId == categoryId);
            }

            var result = await query
                .CountAsync();

            return result;
        }

        public async Task<EventStatisticalInfoViewModel> GetEventStatistics()
        {
            var eventsInfo = await this.eventsRepository
                .All()
                .Select(e => new
                {
                    EventVolunteers = e.Volunteers,
                })
                .ToListAsync();

            var eventsVolunteers = eventsInfo
                .SelectMany(ei => ei.EventVolunteers);

            var goodDeedsCount = eventsVolunteers.Count();

            var activeEventsCount = await this.eventsRepository
                .All()
                .Where(e => e.EndDate >= DateTime.UtcNow)
                .CountAsync();

            var pastEventsCount = await this.eventsRepository
               .All()
               .Where(e => e.EndDate < DateTime.UtcNow)
               .CountAsync();

            var result = new EventStatisticalInfoViewModel
            {
                ActiveEventsCount = activeEventsCount,
                PastEventsCount = pastEventsCount,
                GoodDeedsCount = goodDeedsCount,
            };

            return result;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllCategories()
        {
            var defaultCategory = this.GetDefaultCategoryOption();

            var categories = await this.categoriesRepository
                .All()
                .OrderBy(c => c.Id)
                .Select(c => new KeyValuePair<string, string>(c.Id.ToString(), c.Name))
                .ToListAsync();

            categories.Insert(0, defaultCategory);

            return categories;
        }

        public async Task<CreateEventViewModel> GetEventData(CreateEventViewModel input)
        {
            input.Categories = await this.GetAllCategories();
            input.Regions = await this.GetAllRegions();

            if (input.Location?.RegionId != 0)
            {
                input.Municipalities = await this.GetMunicipalitiesByRegionId(input.Location.RegionId);
            }

            if (input.Location?.MunicipalityId != 0)
            {
                input.Settlements = await this.GetSettlementsByMunicipalityId(input.Location.MunicipalityId);
            }

            input.Phone = new PhoneViewModel();
            input.Phone.Codes = await this.GetAllPhoneCodes();

            return input;
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

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetMunicipalitiesByRegionId(int? regionId)
        {
            var defaultOption = this.GetDefaultOption();
            var municipalities = await this.municipalitiesRepository
                .All()
                .Where(m => m.RegionId == regionId)
                .OrderBy(m => m.Name)
                .Select(m => new KeyValuePair<string, string>(m.Id.ToString(), $"{m.Name}"))
                .ToListAsync();

            municipalities.Insert(0, defaultOption);

            return municipalities;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetSettlementsByMunicipalityId(int? municipalityId)
        {
            var defaultOption = this.GetDefaultOption();
            var settlements = await this.settlementsRepository
                .All()
                .Where(s => s.MunicipalityId == municipalityId)
                .OrderBy(s => s.Name)
                .Select(s => new KeyValuePair<string, string>(s.Id.ToString(), $"{s.Name}"))
                .ToListAsync();

            settlements.Insert(0, defaultOption);

            return settlements;
        }

        public async Task<List<HomeEventViewModel>> GetEventsForHomePage()
            => await this.eventsRepository
                .All()
                .Where(e => e.EndDate > DateTime.UtcNow)
                .Select(e => new HomeEventViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    ThumbnailData = e.Image.ThumbnailData,
                })
                .OrderByDescending(e => e.Id)
                .Take(7)
                .ToListAsync();

        public async Task<T> GetEventById<T>(int id)
            => await this.eventsRepository
            .AllAsNoTracking()
            .Where(e => e.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();

        public async Task AddViewsCount(int id)
        {
            var @event = await this.eventsRepository
                .All()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            @event.ViewsCount++;
            await this.eventsRepository.SaveChangesAsync();
        }

        private KeyValuePair<string, string> GetDefaultOption()
            => new KeyValuePair<string, string>("0", "ИЗБЕРИ");

        private KeyValuePair<string, string> GetDefaultCategoryOption()
            => new KeyValuePair<string, string>("0", "КАТЕГОРИИ");
    }
}
