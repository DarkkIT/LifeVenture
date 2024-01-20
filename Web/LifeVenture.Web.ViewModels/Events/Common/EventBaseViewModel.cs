namespace LifeVenture.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;

    public abstract class EventBaseViewModel : IMapFrom<Event>
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [MaxLength(3000)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Начална дата")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Крайна дата")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Спешен евент")]
        public bool IsUrgent { get; set; }

        [Display(Name = "Максимален брой участници")]
        [Range(1, 2000000000)]
        public int MaxParticipantsCount { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}
