using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Unhcr.ProtectDataHub.Countries;

public interface ICountryAppService:
    ICrudAppService< //Defines CRUD methods
        CountryDto, //Used to show countries
        Guid, //Primary key of the country entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCountryDto> //Used to create/update a country
{
    Task<ListResultDto<RegionLookupDto>> GetRegionLookupAsync();
}
