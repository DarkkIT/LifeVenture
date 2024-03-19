namespace LifeVenture.Web.ViewModels.Common
{
    using LifeVenture.Data.Models.Common;
    using LifeVenture.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public byte[] ThumbnailData { get; set; }
    }
}
