using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Unhcr.ProtectDataHub.Regions;

public class GetRegionListDto: PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
