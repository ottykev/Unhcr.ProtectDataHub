using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Regions;
using Unhcr.ProtectDataHub.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Unhcr.ProtectDataHub.Countries;

namespace Unhcr.GlobalDataHub.Countries;

[Authorize(ProtectDataHubPermissions.Countries.Default)]
public class CountryAppService :
    CrudAppService<Country, CountryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCountryDto>, ICountryAppService
{
    private readonly IRegionRepository _regionRepository;
    public CountryAppService(IRepository<Country, Guid> repository, IRegionRepository regionRepository) : base(repository)
    {
        _regionRepository = regionRepository;
        GetPolicyName = ProtectDataHubPermissions.Countries.Default;
        GetListPolicyName = ProtectDataHubPermissions.Countries.Default;
        CreatePolicyName = ProtectDataHubPermissions.Countries.Create;
        UpdatePolicyName = ProtectDataHubPermissions.Countries.Edit;
        DeletePolicyName = ProtectDataHubPermissions.Countries.Delete;
    }
    public override async Task<CountryDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Country> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join countries and regions
        var query = from country in queryable
                    join region in await _regionRepository.GetQueryableAsync() on country.RegionId equals region.Id
                    where country.Id == id
                    select new { country, region };

        //Execute the query and get the country with region
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Country), id);
        }

        var countryDto = ObjectMapper.Map<Country, CountryDto>(queryResult.country);
        countryDto.RegionName = queryResult.region.Name;
        return countryDto;
    }

    public override async Task<PagedResultDto<CountryDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        //Get the IQueryable<Country> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join countries and regions
        var query = from country in queryable
                    join region in await _regionRepository.GetQueryableAsync() on country.RegionId equals region.Id
                    select new { country, region };

        //Paging
        query = query
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of CountryDto objects
        var countryDtos = queryResult.Select(x =>
        {
            var countryDto = ObjectMapper.Map<Country, CountryDto>(x.country);
            countryDto.RegionName = x.region.Name;
            return countryDto;
        }).ToList();

        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<CountryDto>(
            totalCount,
            countryDtos
        );
    }

    public async Task<ListResultDto<RegionLookupDto>> GetRegionLookupAsync()
    {
        var regions = await _regionRepository.GetListAsync();

        return new ListResultDto<RegionLookupDto>(
            ObjectMapper.Map<List<Region>, List<RegionLookupDto>>(regions)
        );
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"country.{nameof(Country.Name)}";
        }

        if (sorting.Contains("regionName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "regionName",
                "region.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"country.{sorting}";
    }
}