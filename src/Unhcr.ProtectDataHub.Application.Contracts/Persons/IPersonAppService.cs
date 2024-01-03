using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Unhcr.ProtectDataHub.Persons;

public interface IPersonAppService:
    ICrudAppService< //Defines CRUD methods
        PersonDto, //Used to show persons
        Guid, //Primary key of the person entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreatePersonDto,//Used to create a new person
        UpdatePersonDto> //Used to update person
{
    Task<ListResultDto<CountryLookupDto>> GetCountryLookupAsync();
}
