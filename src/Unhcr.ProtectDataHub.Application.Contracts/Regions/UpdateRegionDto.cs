using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unhcr.ProtectDataHub.Regions;

public class UpdateRegionDto
{
    [Required]
    [StringLength(RegionConsts.MaxNameLength)]
    public string Name { get; set; }
}
