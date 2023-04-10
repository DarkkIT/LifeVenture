namespace LifeVenture.Web.ViewModels.Common
{
    using System.Collections.Generic;

    using LifeVenture.Data.Models.Common;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Home;

    public class ImageViewModel : IMapFrom<Image>
    {
        public ImageViewModel()
        {
            this.HomeModels = new HashSet<HomeViewModel>();
        }

        public byte[] Data { get; set; }

        public EventDetailsViewModel Events { get; set; }

        public virtual ICollection<HomeViewModel> HomeModels { get; set; }
    }
}
