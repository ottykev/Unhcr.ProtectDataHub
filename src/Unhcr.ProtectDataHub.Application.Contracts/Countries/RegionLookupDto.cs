using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Unhcr.ProtectDataHub.Countries;

public class RegionLookupDto: EntityDto<Guid>
{
    public string Name { get; set; }
}
