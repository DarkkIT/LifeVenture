namespace LifeVenture.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;

    using static LifeVenture.Common.ErrorConstants.Common;
    using static LifeVenture.Common.ErrorConstants.EventErrors;
    using static LifeVenture.Common.InputConstants.InputCommonConstants;
    using static LifeVenture.Common.InputConstants.InputEventsConstants;

    public abstract class EventBaseViewModel : IMapFrom<Event>
    {
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(MaxEventTitleLenghtNumber, ErrorMessage = MaxTitleLenght)]
        [Display(Name = EventTitle)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(MaxEventDescriptionLenghtNumber, ErrorMessage = DescriptionMaxLength)]
        [Display(Name = EventDescription)]
        public string Description { get; set; }

        [Display(Name = EventStartDate)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = EventEndDate)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = EventUrgency)]
        public bool IsUrgent { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Display(Name = EventMaxParticipants)]
        [Range(MinNumber, EventMaxParticipantsMaxNumber, ErrorMessage = MaxParticipantsCountErr)]
        public int MaxParticipantsCount { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [EmailAddress(ErrorMessage = NotValidEmailAddress)]
        [Display(Name = EventEmail)]
        public string Email { get; set; }
    }
}
