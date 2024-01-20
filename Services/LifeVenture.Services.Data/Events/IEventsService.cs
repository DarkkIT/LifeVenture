﻿namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Image;

    public interface IEventsService
    {
        Task CreateEvent(CreateEventViewModel input, ImageInputModel image, string userId);

        Task<IEnumerable<T>> GetAll<T>();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllCategories();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllPhoneCodes();

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegions();
    }
}
