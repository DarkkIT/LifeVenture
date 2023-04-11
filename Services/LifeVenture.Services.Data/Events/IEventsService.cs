namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;

    public interface IEventsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
