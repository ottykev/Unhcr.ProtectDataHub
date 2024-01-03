using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Unhcr.ProtectDataHub.Countries;
using Volo.Abp.ObjectMapping;

namespace Unhcr.ProtectDataHub.Persons;

[Authorize(ProtectDataHubPermissions.Persons.Default)]
public class PersonAppService :
    CrudAppService<
        Person, //The Person entity
        PersonDto, //Used to show persons
        Guid, //Primary key of the person entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreatePersonDto,//Used to create a new person
        UpdatePersonDto>, //Used to create/update a person
    IPersonAppService //implement the IPersonAppService
{
    private readonly ICountryRepository _countryRepository;
    public PersonAppService(IRepository<Person, Guid> repository, ICountryRepository countryRepository) : base(repository)
    {
        GetPolicyName = ProtectDataHubPermissions.Persons.Default;
        GetListPolicyName = ProtectDataHubPermissions.Persons.Default;
        CreatePolicyName = ProtectDataHubPermissions.Persons.Create;
        UpdatePolicyName = ProtectDataHubPermissions.Persons.Edit;
        DeletePolicyName = ProtectDataHubPermissions.Persons.Delete;
        _countryRepository = countryRepository;
    }
    public override async Task<PersonDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Person> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join persons and countries
        var query = from person in queryable
                    join country in await _countryRepository.GetQueryableAsync() on person.CountryId equals country.Id
                    where person.Id == id
                    select new { person, country };

        //Execute the query and get the person with country
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Person), id);
        }

        var personDto = ObjectMapper.Map<Person, PersonDto>(queryResult.person);
        personDto.CountryName = queryResult.country.Name;
        return personDto;
    }
    public override async Task<PagedResultDto<PersonDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        //Get the IQueryable<Person> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join persons and countries
        var query = from person in queryable
                    join country in await _countryRepository.GetQueryableAsync() on person.CountryId equals country.Id
                    select new { person, country };

        //Paging
        query = query
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of PersonDto objects
        var personDtos = queryResult.Select(x =>
        {
            var personDto = ObjectMapper.Map<Person, PersonDto>(x.person);
            personDto.CountryName = x.country.Name;
            return personDto;
        }).ToList();

        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<PersonDto>(
                       totalCount,
                                  personDtos
                                         );
    }
    public async Task<ListResultDto<CountryLookupDto>> GetCountryLookupAsync()
    {
        var countries = await _countryRepository.GetListAsync();

        return new ListResultDto<CountryLookupDto>(
            ObjectMapper.Map<List<Country>, List<CountryLookupDto>>(countries)
        );
    }
    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"person.{nameof(Person.FullName)}";
        }

        if (sorting.Contains("countryName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "countryName",
                "country.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"person.{sorting}";
    }
}
