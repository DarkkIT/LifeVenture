namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LifeVenture.Data.Common.Repositories;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;

    public class EventsService : IEventsService
    {
        private readonly IDeletableEntityRepository<Event> eventsRepository;

        public EventsService(IDeletableEntityRepository<Event> eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.eventsRepository.All().To<T>().ToList();
        }
    }
}
