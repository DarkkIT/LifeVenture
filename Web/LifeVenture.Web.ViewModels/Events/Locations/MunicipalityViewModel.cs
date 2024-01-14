namespace LifeVenture.Web.ViewModels.Events.Locations
{
    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Services.Mapping;

    public class MunicipalityViewModel : BaseLocationsViewModel, IMapFrom<Municipality>
    {
    }
}
