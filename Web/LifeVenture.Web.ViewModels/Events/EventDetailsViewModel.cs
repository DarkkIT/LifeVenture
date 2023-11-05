namespace LifeVenture.Web.ViewModels.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Users;

    public class EventDetailsViewModel : IMapFrom<Event>
    {
        public EventDetailsViewModel()
        {
            this.Locations = new HashSet<LocationViewModel>();
        }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [MaxLength(3000)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Начална дата")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Крайна дата")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Спешен евент")]
        public bool IsUrgent { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Одобрен евент")]
        public bool IsApproved { get; set; }

        public virtual PhoneViewModel Phone { get; set; }

        public virtual RepeatabilityViewModel Repeatability { get; set; }

        public virtual ApplicationUserViewModel CreatedBy { get; set; }

        public virtual CategoryViewModel Category { get; set; }

        public virtual ICollection<LocationViewModel> Locations { get; set; }
    }
}
