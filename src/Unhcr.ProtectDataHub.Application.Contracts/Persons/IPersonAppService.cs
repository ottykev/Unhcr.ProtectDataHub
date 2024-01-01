using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Unhcr.ProtectDataHub.Persons;

public interface IPersonAppService: IApplicationService
{
    Task<PersonDto> GetAsync(Guid id);
    Task<PagedResultDto<PersonDto>> GetListAsync(GetPersonListDto input);
    Task<PersonDto> CreateAsync(CreatePersonDto input);
    Task UpdateAsync(Guid id, UpdatePersonDto input);
    Task DeleteAsync(Guid id);
}
