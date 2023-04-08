namespace LifeVenture.Data.Models.Home
{
    using System.Collections.Generic;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Common;

    public class HomeModel : BaseModel<int>
    {
        public HomeModel()
        {
            this.Images = new HashSet<Image>();
        }

        public virtual ICollection<Image> Images { get; set; }
    }
}
