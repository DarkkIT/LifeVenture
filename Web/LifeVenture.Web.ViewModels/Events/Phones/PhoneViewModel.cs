namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PhoneViewModel
    {
        [Display(Name = "Телефонен номер")]
        public string Number { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Codes { get; set; }
    }
}
