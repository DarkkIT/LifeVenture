namespace LifeVenture.Data.Models.Locations
{
    using System.Collections.Generic;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Events;

    public class Location : BaseDeletableModel<int>
    {
        public Location()
        {
            this.Events = new HashSet<Event>();
        }

        public int RegionId { get; set; }

        public Region Region { get; set; }

        public int MunicipalityId { get; set; }

        public Municipality Municipality { get; set; }

        public int SettlementId { get; set; }

        public Settlement Settlement { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
