namespace LifeVenture.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using LifeVenture.Web.ViewModels.Events;

    public class HomeViewModel
    {
        public StatisticalInfoViewModel StatisticalInfo { get; set; }

        public List<HomeEventViewModel> Events { get; set; }
    }
}
