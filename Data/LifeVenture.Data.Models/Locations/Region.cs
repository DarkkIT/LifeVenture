namespace LifeVenture.Data.Models.Locations
{
    using System.Collections.Generic;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Locations.Interfaces;

    public class Region : BaseDeletableModel<int>, ILocation
    {
        public Region()
        {
            this.Municipalities = new HashSet<Municipality>();
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<Municipality> Municipalities { get; set; }
    }
}
