namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using static LifeVenture.Common.ErrorConstants.Common;
    using static LifeVenture.Common.InputConstants.InputCommonConstants;
    using static LifeVenture.Common.InputConstants.InputEventsConstants;

    public class CreateEventViewModel : EventBaseViewModel
    {
        public PhoneViewModel Phone { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Display(Name = EventCategory)]
        [Range(MinNumber, int.MaxValue, ErrorMessage = SelectOptionErr)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = ImageIsRequired)]
        public IFormFile Image { get; set; }

        public LocationViewModel Location { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Municipalities { get; set; } /* => new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("0", "ИЗБЕРИ") };*/

        public IEnumerable<KeyValuePair<string, string>> Settlements { get; set; } /* => new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("0", "ИЗБЕРИ") };*/
    }
}
