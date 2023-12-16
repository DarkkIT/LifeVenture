namespace LifeVenture.Data.Models.Locations
{
    using System.Collections.Generic;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Locations.Interfaces;

    public class Municipality : BaseDeletableModel<int>, ILocation
    {
        public Municipality()
        {
            this.Settlements = new HashSet<Settlement>();
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public int RegionId { get; set; }

        public Region Region { get; set; }

        public ICollection<Settlement> Settlements { get; set; }
    }
}
