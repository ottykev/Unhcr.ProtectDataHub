using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Unhcr.ProtectDataHub.Regions;

public class Region : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }

    private Region()
    {

    }
    internal Region(
        Guid id, string name
        )
        : base(id)
    {
        SetName(name);

    }
    internal Region ChangeName(string name)
    {
        SetName(name);
        return this;
    }
    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), RegionConsts.MaxNameLength);
    }
}
