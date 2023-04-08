namespace LifeVenture.Web.ViewModels.Events
{
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;

    public class RepeatabilityViewModel : IMapFrom<Repeatability>
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
