using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Unhcr.ProtectDataHub.Countries;

public interface ICountryAppService:
    ICrudAppService<
               CountryDto,
                      Guid,
                             PagedAndSortedResultRequestDto,
                                    CreateCountryDto,
                                           UpdateCountryDto>
{
    Task<ListResultDto<RegionLookupDto>> GetRegionLookupAsync();
}
