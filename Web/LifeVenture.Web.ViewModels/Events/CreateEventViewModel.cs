namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateEventViewModel : EventBaseViewModel
    {
        public PhoneViewModel Phone { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Display(Name = "Снимка")]
        public IFormFile Image { get; set; }

        public IList<LocationViewModel> Locations { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Municipalities => new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("0", "ИЗБЕРИ") };

        public IEnumerable<KeyValuePair<string, string>> Settlements => new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("0", "ИЗБЕРИ") };
    }
}
