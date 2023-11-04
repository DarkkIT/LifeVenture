namespace LifeVenture.Data.Models.People
{
    using System.Diagnostics.CodeAnalysis;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Common;

    public class Volunteer : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public ApplicationUser User { get; set; }

        public ImagePeople Image { get; set; }
    }
}
