namespace LifeVenture.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using LifeVenture.Data.Models.Home;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Common;
    using LifeVenture.Web.ViewModels.Events;

    public class HomeViewModel : IMapFrom<HomeModel>
    {
        public HomeViewModel()
        {
            this.Images = new HashSet<ImageViewModel>();
        }

        public StatisticalInfo StatisticalInfo { get; set; }

        public virtual ICollection<ImageViewModel> Images { get; set; }

        public virtual ICollection<EventViewModel> Events { get; set; }
    }
}
