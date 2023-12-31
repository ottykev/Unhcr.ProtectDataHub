using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Unhcr.ProtectDataHub.Countries;

public interface ICountryAppService: ICrudAppService<CountryDto, Guid, CreateUpdateCountryDto, CreateUpdateCountryDto>
{
}
