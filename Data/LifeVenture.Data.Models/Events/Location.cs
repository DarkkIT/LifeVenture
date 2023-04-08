namespace LifeVenture.Data.Models.Events
{
    using System.Collections.Generic;

    using LifeVenture.Data.Common.Models;

    public class Location : BaseDeletableModel<int>
    {
        public Location()
        {
            this.Events = new HashSet<Event>();
        }

        public virtual ICollection<Event> Events { get; set; }
    }
}
