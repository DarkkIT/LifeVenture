namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;

    using LifeVenture.Web.ViewModels.Image;

    public class CreateEventInputModel : EventBaseViewModel
    {
        public int CategoryId { get; set; }

        public PhoneViewModel Phone { get; set; }

        public ImageInputModel Image { get; set; }

        public IList<LocationViewModel> Locations { get; set; }
    }
}
