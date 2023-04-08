namespace LifeVenture.Data.Models.Events
{
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Common.Models;

    public class Repeatability : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}