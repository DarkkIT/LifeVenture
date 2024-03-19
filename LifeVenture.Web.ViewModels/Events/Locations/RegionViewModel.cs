namespace LifeVenture.Web.ViewModels.Events.Locations
{
    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Services.Mapping;

    public class RegionViewModel : BaseLocationsViewModel, IMapFrom<Region>
    {
    }
}
