namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LifeVenture.Data.Common.Repositories;
    using LifeVenture.Data.Models;
    using LifeVenture.Services.Mapping;

    public class EventsService : IEventsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;

        public EventsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }
    }
}
