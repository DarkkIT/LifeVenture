namespace LifeVenture.Services.Data
{
    using System.Threading.Tasks;

    using LifeVenture.Data.Models.Common;
    using LifeVenture.Web.ViewModels.Image;

    public interface IImageService
    {
        Task<Image> GetImageData(ImageInputModel image);
    }
}
