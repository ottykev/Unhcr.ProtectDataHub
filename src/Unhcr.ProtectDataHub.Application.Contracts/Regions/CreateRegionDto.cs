using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unhcr.ProtectDataHub.Regions;

public class CreateRegionDto
{
    [Required]
    [StringLength(RegionConsts.MaxNameLength)]
    public string Name { get; set; }
}
