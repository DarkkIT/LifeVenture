namespace LifeVenture.Data.Models.Common
{
    using LifeVenture.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        public byte[] Data { get; set; }
    }
}
