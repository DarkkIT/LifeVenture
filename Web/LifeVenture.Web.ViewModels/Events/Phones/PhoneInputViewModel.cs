namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PhoneInputViewModel
    {
        [Display(Name = "Телефонен номер")]
        public string Number { get; set; }

        [Display(Name = "Код на държава")]
        public int CodeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Codes { get; set; }
    }
}
