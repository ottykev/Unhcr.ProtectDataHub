using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Unhcr.ProtectDataHub.Regions;

public interface IRegionAppService: IApplicationService
{
    Task<RegionDto> GetAsync(Guid id);
    Task<PagedResultDto<RegionDto>> GetListAsync(GetRegionListDto input);
    Task<RegionDto> CreateAsync(CreateRegionDto input);
    Task UpdateAsync(Guid id, UpdateRegionDto input);
    Task DeleteAsync(Guid id);
}
