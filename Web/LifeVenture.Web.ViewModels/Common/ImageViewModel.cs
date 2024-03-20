namespace LifeVenture.Web.ViewModels.Common
{
    using System;

    using LifeVenture.Data.Models.Common;
    using LifeVenture.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public byte[] ThumbnailData { get; set; }

        public string ThumbnailAsBase64 => Convert.ToBase64String(this.ThumbnailData);
    }
}
