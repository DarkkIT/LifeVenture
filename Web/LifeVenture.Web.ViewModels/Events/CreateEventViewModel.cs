namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateEventViewModel : EventBaseViewModel
    {
        public PhoneViewModel Phone { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public IList<LocationViewModel1> Locations { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Municipalities => new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("0", "ИЗБЕРИ") };

        public IEnumerable<KeyValuePair<string, string>> Settlements => new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("0", "ИЗБЕРИ") };
    }

    public class LocationViewModel1
    {
        [Display(Name = "Регион")]
        public int RegionId { get; set; }

        [Display(Name = "Община")]
        public int MunicipalityId { get; set; }

        [Display(Name = "Населено място")]
        public int SettlementId { get; set; }

        [Display(Name = "Допълнителна информация за адрес")]
        public string AddressNote { get; set; }
    }
}
