namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;

    using LifeVenture.Web.ViewModels.Common;

    public class EventsListingViewModel<T>
    {
        //public EventsFiltersInputViewModel Filters { get; set; }

        public PaginatedList<EventViewModel> PaginatedEvents { get; set; }

        public IEnumerable<T> Categories { get; set; }
    }
}
