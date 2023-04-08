namespace LifeVenture.Data.Models.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
            this.Locations = new HashSet<Location>();
        }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(3000)]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsUrgent { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public bool IsInDrafts { get; set; }

        public bool IsApproved { get; set; }

        public int PhoneId { get; set; }

        public virtual Phone Phone { get; set; }

        public int RepeatabilityId { get; set; }

        public virtual Repeatability Repeatability { get; set; }

        public string CreatedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual IEnumerable<Location> Locations { get; set; }
    }
}
