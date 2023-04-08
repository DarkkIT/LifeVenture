namespace LifeVenture.Data.Models.Events
{
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Common.Models;

    public class CountryPhoneCode : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(150)]
        public string Country { get; set; }
    }
}