namespace LifeVenture.Web.Controllers
{
    using System.Threading.Tasks;

    using LifeVenture.Services.Data;
    using LifeVenture.Web.ViewModels.Events.Locations;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class LocationsApiController : ControllerBase
    {
        private readonly ILocationsService locationService;

        public LocationsApiController(ILocationsService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        [Route("GetRegions")]
        public async Task<ActionResult<MunicipalityViewModel>> GetGetRegions()
        {
            var regionsDtos = await this.locationService.GetRegions<RegionViewModel>();
            return this.Ok(regionsDtos);
        }

        [HttpGet]
        [Route("GetMunicipalities")]
        public async Task<ActionResult<MunicipalityViewModel>> GetMunicipalities(int regionId)
        {
            if (regionId == 0)
            {
                return this.BadRequest();
            }

            var municipalitiesDtos = await this.locationService.GetMunicipalitiesByRegion<MunicipalityViewModel>(regionId);
            return this.Ok(municipalitiesDtos);
        }

        [HttpGet]
        [Route("GetSettlements")]
        public async Task<ActionResult<SettlementViewModel>> GetSettlements(int municipalityId)
        {
            if (municipalityId == 0)
            {
                return this.BadRequest();
            }

            var result = await this.locationService.GetSettlementsByMunicipality<SettlementViewModel>(municipalityId);
            return this.Ok(result);
        }
    }
}
