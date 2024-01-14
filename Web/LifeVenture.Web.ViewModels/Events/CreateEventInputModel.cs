namespace LifeVenture.Web.ViewModels.Events
{
    public class CreateEventInputModel : EventBaseViewModel
    {
        public int CategoryId { get; set; }

        public PhoneInputViewModel Phone { get; set; }
    }
}
