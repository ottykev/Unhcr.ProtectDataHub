using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Unhcr.ProtectDataHub.Regions;
[Authorize(ProtectDataHubPermissions.Regions.Default)]
public class RegionAppService : ProtectDataHubAppService, IRegionAppService
{
    private readonly IRegionRepository _regionRepository;
    private readonly RegionManager _regionManager;

    public RegionAppService(
               IRegionRepository regionRepository,
                      RegionManager regionManager)
    {
        _regionRepository = regionRepository;
        _regionManager = regionManager;
    }

    public async Task<RegionDto> GetAsync(Guid id)
    {
        var region = await _regionRepository.GetAsync(id);
        return ObjectMapper.Map<Region, RegionDto>(region);
    }

    public async Task<PagedResultDto<RegionDto>> GetListAsync(GetRegionListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Region.Name);
        }
        var regions = await _regionRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
            );
        var totalCount = input.Filter == null
            ? await _regionRepository.CountAsync()
            : await _regionRepository.CountAsync(region => region.Name.Contains(input.Filter));

        return new PagedResultDto<RegionDto>(
                           totalCount,
                                          ObjectMapper.Map<List<Region>, List<RegionDto>>(regions)
                                                     );

    }
    [Authorize(ProtectDataHubPermissions.Regions.Create)]
    public async Task<RegionDto> CreateAsync(CreateRegionDto input)
    {
        var region = await _regionManager.CreateAsync(input.Name);
        await _regionRepository.InsertAsync(region);
        return ObjectMapper.Map<Region, RegionDto>(region);
    }
    [Authorize(ProtectDataHubPermissions.Regions.Edit)]
    public async Task UpdateAsync(Guid id, UpdateRegionDto input)
    {
        var region = await _regionRepository.GetAsync(id);
        if (region.Name != input.Name)
        {
            await _regionManager.ChangeNameAsync(region, input.Name);
        }
        await _regionRepository.UpdateAsync(region);
    }
    [Authorize(ProtectDataHubPermissions.Regions.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _regionRepository.DeleteAsync(id);
    }
}

    
