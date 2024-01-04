using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unhcr.ProtectDataHub.Countries;

public class CreateCountryDto
{
    [Required]
    [StringLength(CountryConsts.MaxNameLength)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(CountryConsts.MaxCodeLength)]
    public string Code { get; set; } = string.Empty;
    [Required]
    public Cluster ClusterStructure { get; set; } = Cluster.None;
    public Guid RegionId { get; set; }
}
