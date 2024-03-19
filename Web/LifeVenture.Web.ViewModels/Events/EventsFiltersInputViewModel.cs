namespace LifeVenture.Web.ViewModels.Events
{
    public class EventsFiltersInputViewModel
    {
        public bool Latest { get; set; }

        public bool MostPopular { get; set; }

        public bool MostVisited { get; set; }

        public int CategoryId { get; set; }
    }
}
