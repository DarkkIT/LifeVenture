namespace LifeVenture.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Events;

    public class Image : BaseModel<int>
    {
        [Required]
        [MaxLength(1000)]
        public string OriginalName { get; set; }

        [Required]
        [MaxLength(100)]
        public string OriginalContentType { get; set; }

        public byte[] OriginalData { get; set; }

        public byte[] ThumbnailData { get; set; }

        public byte[] FullscreenData { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public ApplicationUser User { get; set; }
    }
}
