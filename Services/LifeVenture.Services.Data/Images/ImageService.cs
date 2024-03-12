namespace LifeVenture.Services.Data.Images
{
    using System.IO;
    using System.Threading.Tasks;

    using LifeVenture.Web.ViewModels.Image;

    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats.Jpeg;
    using SixLabors.ImageSharp.Processing;

    using static LifeVenture.Common.InputConstants.InputImageConstants;

    public class ImageService : IImageService
    {
        public async Task<LifeVenture.Data.Models.Common.Image> GetImageData(ImageInputModel image)
        {
            if (image.Content == null)
            {
                return null;
            }

            using var imageResult = await Image.LoadAsync(image.Content);

            //var aspectRatio = (double)imageResult.Width / imageResult.Height;
            //var is16To9 = Math.Abs(aspectRatio - (16.0 / 9.0)) < double.Epsilon;

            var originalData = await this.GetImageData(imageResult, imageResult.Width);
            var fullscreenData = await this.GetImageData(imageResult, FullscreenWidth);
            var thumbnailData = await this.GetImageData(imageResult, ThumbnailWidth);

            var result = new LifeVenture.Data.Models.Common.Image
            {
                OriginalContentType = image.Type,
                OriginalName = image.Name,
                OriginalData = originalData,
                FullscreenData = fullscreenData,
                ThumbnailData = thumbnailData,
            };

            return result;
        }

        private async Task<byte[]> GetImageData(Image imageResult, int resizeWidth)
        {
            var width = imageResult.Width;
            var height = imageResult.Height;

            if (width > resizeWidth)
            {
                //height = (int)((double)resizeWidth / width * height);
                height = (int)((double)resizeWidth / AspectRatioNumber);
                width = resizeWidth;
            }

            imageResult.Mutate(i => i.Resize(new Size(width, height)));

            imageResult.Metadata.ExifProfile = null;

            await using var memoryStream = new MemoryStream();
            await imageResult.SaveAsJpegAsync(memoryStream, new JpegEncoder { Quality = Quality });

            var imageData = memoryStream.ToArray();
            return imageData;
        }
    }
}
