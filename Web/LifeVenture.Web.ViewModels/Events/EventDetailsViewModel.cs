namespace LifeVenture.Web.ViewModels.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Common;
    using LifeVenture.Web.ViewModels.Users;

    public class EventDetailsViewModel : IMapFrom<Event>
    {
        public EventDetailsViewModel()
        {
            this.Locations = new HashSet<LocationViewModel>();
            this.Images = new HashSet<ImageViewModel>();
        }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(3000)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsUrgent { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public bool IsInDrafts { get; set; }

        public bool IsApproved { get; set; }

        public int PhoneId { get; set; }

        public virtual PhoneViewModel Phone { get; set; }

        public int RepeatabilityId { get; set; }

        public virtual RepeatabilityViewModel Repeatability { get; set; }

        public string CreatedById { get; set; }

        public virtual ApplicationUserViewModel CreatedBy { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryViewModel Category { get; set; }

        public virtual ICollection<LocationViewModel> Locations { get; set; }

        public virtual ICollection<ImageViewModel> Images { get; set; }
    }
}
