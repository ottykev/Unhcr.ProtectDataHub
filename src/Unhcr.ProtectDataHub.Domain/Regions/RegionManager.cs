using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Unhcr.ProtectDataHub.Regions;

public class RegionManager: DomainService
{
    private readonly IRegionRepository _regionRepository;

    public RegionManager(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public async Task<Region> CreateAsync(
               string name
               )
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingRegion = await _regionRepository.FindByNameAsync(name);
        if (existingRegion != null)
        {
            throw new RegionAlreadyExistsException(name);
        }

        return new Region(
                       GuidGenerator.Create(),
                                  name
                                             );
    }

    public async Task ChangeNameAsync(
               Region region,
                      string name
               )
    {
        Check.NotNull(region, nameof(region));
        Check.NotNullOrWhiteSpace(name, nameof(name));
        var existingRegion = await _regionRepository.FindByNameAsync(name);
        if (existingRegion != null && existingRegion.Id != region.Id)
        {
            throw new RegionAlreadyExistsException(name);
        }

        region.ChangeName(name);
    }
}
