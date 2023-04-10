namespace LifeVenture.Data.Models.Common
{
    using System.Collections.Generic;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Data.Models.Home;

    public class Image : BaseModel<int>
    {
        public Image()
        {
            this.HomeModels = new HashSet<HomeModel>();
        }

        public byte[] Data { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public virtual ICollection<HomeModel> HomeModels { get; set; }
    }
}
