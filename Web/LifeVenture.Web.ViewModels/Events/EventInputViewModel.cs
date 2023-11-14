namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class EventInputViewModel : EventBaseViewModel
    {
        public IFormFile Image { get; set; }

        public PhoneInputViewModel Phone { get; set; }

        [Display(Name = "Категории")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
