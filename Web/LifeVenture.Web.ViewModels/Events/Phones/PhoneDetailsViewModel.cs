namespace LifeVenture.Web.ViewModels.Events
{
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;

    public class PhoneDetailsViewModel : IMapFrom<Phone>
    {
        [Required]
        [MaxLength(30)]
        public string Number { get; set; }

        public virtual CountryPhoneCodeViewModel Code { get; set; }
    }
}
