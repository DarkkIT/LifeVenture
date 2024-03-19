namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static LifeVenture.Common.ErrorConstants.Common;
    using static LifeVenture.Common.ErrorConstants.PhoneNumberErrors;
    using static LifeVenture.Common.InputConstants.InputPhoneConstants;

    public class PhoneViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        [Display(Name = PhoneNumber)]
        [StringLength(maximumLength: MaxPhoneNumberLenght, MinimumLength = MinPhoneNumberLenght, ErrorMessage = NumberErr)]
        public string Number { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Display(Name = PhoneCode)]
        public int CodeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Codes { get; set; }
    }
}
