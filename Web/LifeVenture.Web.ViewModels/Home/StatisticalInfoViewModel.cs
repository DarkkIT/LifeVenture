namespace LifeVenture.Web.ViewModels.Home
{
    using LifeVenture.Data.Models.Home;
    using LifeVenture.Services.Mapping;

    public class StatisticalInfoViewModel : IMapFrom<StatisticalInfo>
    {
        public int ActiveEvents { get; set; }

        public int EndedEvents { get; set; }

        public int TotalGoodDeeds { get; set; }

        public int PeopleOfGoodness { get; set; }

        public int Volunteers { get; set; }
    }
}
