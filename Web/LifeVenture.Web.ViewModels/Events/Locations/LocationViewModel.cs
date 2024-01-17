namespace LifeVenture.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Services.Mapping;

    public class LocationViewModel : IMapFrom<Location>
    {
        [Display(Name = "Регион")]
        public int RegionId { get; set; }

        [Display(Name = "Община")]
        public int MunicipalityId { get; set; }

        [Display(Name = "Населено място")]
        public int SettlementId { get; set; }

        [Display(Name = "Уточнение за адрес")]
        public string AddressNote { get; set; }
    }
}
