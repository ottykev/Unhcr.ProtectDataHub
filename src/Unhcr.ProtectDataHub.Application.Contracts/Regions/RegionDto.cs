using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Unhcr.ProtectDataHub.Regions;

public class RegionDto: EntityDto<Guid>
{
    public string Name { get; set; }
}
