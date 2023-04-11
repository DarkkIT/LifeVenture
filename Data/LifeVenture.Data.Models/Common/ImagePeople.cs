namespace LifeVenture.Data.Models.Common
{
    using System.Diagnostics.CodeAnalysis;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.People;

    public class ImagePeople : BaseDeletableModel<int>
    {
        public byte[] Data { get; set; }

        [AllowNull]
        public int PersonOfGoodnesId { get; set; }

        public PersonOfGoodness PersonOfGoodnes { get; set; }

        [AllowNull]
        public int VolunteerId { get; set; }

        public Volunteer Volunteer { get; set; }
    }
}
