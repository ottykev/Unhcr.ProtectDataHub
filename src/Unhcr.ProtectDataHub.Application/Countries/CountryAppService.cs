using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Permissions;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Unhcr.ProtectDataHub.Countries;

public class CountryAppService: CrudAppService<Country, CountryDto, Guid, CreateUpdateCountryDto, CreateUpdateCountryDto>, ICountryAppService
{
    public CountryAppService(IRepository<Country, Guid> repository) : base(repository)
    {
        GetPolicyName = ProtectDataHubPermissions.Countries.Default;
        GetListPolicyName = ProtectDataHubPermissions.Countries.Default;
        CreatePolicyName = ProtectDataHubPermissions.Countries.Create;
        UpdatePolicyName = ProtectDataHubPermissions.Countries.Edit;
        DeletePolicyName = ProtectDataHubPermissions.Countries.Delete;
    }
}
