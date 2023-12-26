namespace LifeVenture.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationsService
    {
        Task<IEnumerable<T>> GetMunicipalitiesByRegion<T>(int regionId);

        Task<IEnumerable<T>> GetSettlementsByMunicipality<T>(int municipalityId);
    }
}
