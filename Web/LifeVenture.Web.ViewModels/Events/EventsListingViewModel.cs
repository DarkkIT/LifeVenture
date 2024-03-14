namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;

    public class EventsListingViewModel
    {
        public int EventsCount { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
