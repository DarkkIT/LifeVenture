namespace LifeVenture.Data.Models.Home
{
    using System.Collections.Generic;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Common;
    using LifeVenture.Data.Models.Events;

    public class HomeModel : BaseModel<int>
    {
        public HomeModel()
        {
            this.Images = new HashSet<Image>();
        }

        public StatisticalInfo StatisticalInfo { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual IEnumerable<Event> Events { get; set; }
    }
}
