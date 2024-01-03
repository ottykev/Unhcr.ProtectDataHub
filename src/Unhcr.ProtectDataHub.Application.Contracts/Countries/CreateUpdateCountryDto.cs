using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unhcr.ProtectDataHub.Countries;

public class CreateUpdateCountryDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(2)]
    public string IsoCode { get; set; } = string.Empty;
    public Guid RegionId { get; set; }
    [Required] public Cluster ClusterStructure { get; set; }
}
