namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public CategoryViewModel()
        {
            this.Events = new HashSet<EventViewModel>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<EventViewModel> Events { get; set; }
    }
}
