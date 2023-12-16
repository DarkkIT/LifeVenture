namespace LifeVenture.Data.Models.Locations
{
    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Locations.Interfaces;

    public class Settlement : BaseDeletableModel<int>, ILocation
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int MunicipalityId { get; set; }

        public Municipality Municipality { get; set; }
    }
}
