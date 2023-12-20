﻿namespace LifeVenture.Web.ViewModels.Events
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

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Municipalities => new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("0", "ИЗБЕРИ") };

        public IEnumerable<KeyValuePair<string, string>> Settlements => new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("0", "ИЗБЕРИ") };

        //[Display(Name = "Място")]
        //public int LocationId { get; set; }

        //public IEnumerable<KeyValuePair<string, string>> Locations { get; set; }
    }
}
