namespace LifeVenture.Data.Models.Home
{
    using LifeVenture.Data.Common.Models;

    public class StatisticalInfo : BaseDeletableModel<int>
    {
        public int ActiveEvents { get; set; }

        public int EndedEvents { get; set; }

        public int TotalGoodDeeds { get; set; }

        public int PeopleOfGoodness { get; set; }

        public int Volunteers { get; set; }
    }
}
