namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Web.ViewModels.Users;

    public class EventDetailsViewModel : EventBaseViewModel
    {
        public EventDetailsViewModel()
        {
            //this.Locations = new HashSet<LocationViewModel>();
        }

        [Display(Name = "Одобрен евент от администратор")]
        public bool IsApproved { get; set; }

        [Display(Name = "За одобрение")]
        public bool IsInDrafts { get; set; }

        public virtual PhoneDetailsViewModel Phone { get; set; }

        public virtual RepeatabilityViewModel Repeatability { get; set; }

        public virtual ApplicationUserViewModel CreatedBy { get; set; }

        public virtual CategoryViewModel Category { get; set; }

        //public virtual ICollection<LocationViewModel> Locations { get; set; }
    }
}
