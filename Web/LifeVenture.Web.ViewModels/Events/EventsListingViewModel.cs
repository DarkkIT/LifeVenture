namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;

    public class EventsListingViewModel
    {
        public EventsFiltersInputViewModel Filters { get; set; }

        public int EventsCount { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
