namespace LifeVenture.Web.ViewModels.Events
{
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;

    public class CountryPhoneCodeViewModel : IMapFrom<CountryPhoneCode>
    {
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(150)]
        public string Country { get; set; }
    }
}
