namespace LifeVenture.Data.Models.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Data.Models.Home;

    public class Image : BaseModel<int>
    {
        public Image()
        {
            this.HomeModels = new HashSet<HomeModel>();
        }

        [Required]
        [MaxLength(1000)]
        public string OriginalName { get; set; }

        [Required]
        [MaxLength(100)]
        public string OriginalContentType { get; set; }

        public byte[] OriginalData { get; set; }

        public byte[] ThumbnailData { get; set; }

        public byte[] FullscreenData { get; set; }

        public Event Event { get; set; }

        public virtual ICollection<HomeModel> HomeModels { get; set; }
    }
}
