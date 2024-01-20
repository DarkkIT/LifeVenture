namespace LifeVenture.Web.ViewModels.Events
{
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Services.Mapping;

    using static LifeVenture.Common.ErrorConstants.Common;
    using static LifeVenture.Common.InputConstants.InputCommonConstants;
    using static LifeVenture.Common.InputConstants.InputLocationConstants;

    public class LocationViewModel : IMapFrom<Location>
    {
        [Display(Name = LocationRegion)]
        ////[Range(MinNumber, int.MaxValue, ErrorMessage = SelectOptionErr)]
        public int RegionId { get; set; }

        [Display(Name = LocationMunicipality)]
        ////[Range(MinNumber, int.MaxValue, ErrorMessage = SelectOptionErr)]
        public int MunicipalityId { get; set; }

        [Display(Name = LocationSettlement)]
        ////[Range(MinNumber, int.MaxValue, ErrorMessage = SelectOptionErr)]
        public int SettlementId { get; set; }

        [Display(Name = LocationAddressNote)]
        public string AddressNote { get; set; }
    }
}
