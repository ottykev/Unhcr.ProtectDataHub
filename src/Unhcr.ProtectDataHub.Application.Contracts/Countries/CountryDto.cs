﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Unhcr.ProtectDataHub.Countries;

public class CountryDto:AuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Cluster ClusterStructure { get; set; }
    public Guid RegionId { get; set; }
    public string RegionName { get; set; }
}
