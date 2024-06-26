﻿namespace LifeVenture.Services.Data.Locations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LifeVenture.Data.Common.Repositories;
    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class LocationsService : ILocationsService

    {
        private readonly IDeletableEntityRepository<Municipality> municipalitiesRepository;
        private readonly IDeletableEntityRepository<Settlement> settlementsRepository;
        private readonly IDeletableEntityRepository<Region> regionsRepository;

        public LocationsService(
            IDeletableEntityRepository<Municipality> municipalitiesRepository,
            IDeletableEntityRepository<Settlement> settlementsRepository,
            IDeletableEntityRepository<Region> regionsRepository)
        {
            this.municipalitiesRepository = municipalitiesRepository;
            this.settlementsRepository = settlementsRepository;
            this.regionsRepository = regionsRepository;
        }

        public async Task<IEnumerable<T>> GetRegions<T>()
           => await this.regionsRepository
               .All()
               .To<T>()
               .ToListAsync();

        public async Task<IEnumerable<T>> GetMunicipalitiesByRegion<T>(int regionId)
            => await this.municipalitiesRepository
                .All()
                .Where(m => m.RegionId == regionId)
                .To<T>()
                .ToListAsync();

        public async Task<IEnumerable<T>> GetSettlementsByMunicipality<T>(int municipalityId)
            => await this.settlementsRepository
                .All()
                .Where(s => s.MunicipalityId == municipalityId)
                .To<T>()
                .ToListAsync();
    }
}
