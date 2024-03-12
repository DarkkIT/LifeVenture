namespace LifeVenture.Web.ViewModels.Home
{
    using LifeVenture.Web.ViewModels.Users;

    public class StatisticalInfoViewModel
    {
        public EventStatisticalInfoViewModel EventStatistic { get; set; }

        public UserStatisticalInfoViewModel UserStatistic { get; set; }
    }
}
