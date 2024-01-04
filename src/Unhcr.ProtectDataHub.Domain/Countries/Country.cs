using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Unhcr.ProtectDataHub.Countries;

public class Country:AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Cluster ClusterStructure { get; set; }
    public Guid RegionId { get; set; }
}
