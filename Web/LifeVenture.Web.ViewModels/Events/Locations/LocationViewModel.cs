namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Services.Mapping;

    public class LocationViewModel : IMapFrom<Location>
    {
        public LocationViewModel()
        {
            this.Events = new HashSet<EventDetailsViewModel>();
        }

        public virtual ICollection<EventDetailsViewModel> Events { get; set; }
    }
}
