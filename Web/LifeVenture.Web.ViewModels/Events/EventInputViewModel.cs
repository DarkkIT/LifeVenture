namespace LifeVenture.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class EventInputViewModel
    {
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

        public IFormFile Image { get; set; }

        // TODO Repeatability

        // public int PhoneId { get; set; }

        // public virtual Phone Phone { get; set; }

        // public int CategoryId { get; set; }

        // public virtual Category Category { get; set; }

        // public virtual ICollection<Location> Locations { get; set; }

        // public virtual ICollection<Image> Images { get; set; }
    }
}
