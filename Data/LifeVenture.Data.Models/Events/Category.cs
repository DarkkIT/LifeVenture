namespace LifeVenture.Data.Models.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Events = new HashSet<Event>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}