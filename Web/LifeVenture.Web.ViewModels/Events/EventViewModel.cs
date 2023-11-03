namespace LifeVenture.Web.ViewModels.Events
{
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Common;

    public class EventViewModel : IMapFrom<Event>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ImageViewModel Image { get; set; }
    }
}
