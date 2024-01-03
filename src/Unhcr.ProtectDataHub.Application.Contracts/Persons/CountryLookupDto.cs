using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Unhcr.ProtectDataHub.Persons;

public class CountryLookupDto: EntityDto<Guid>
{
    public string Name { get; set; }
}
