using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Unhcr.ProtectDataHub.Regions;

public class RegionAlreadyExistsException: BusinessException
{
    public RegionAlreadyExistsException(string name)
        : base(ProtectDataHubDomainErrorCodes.RegionAlreadyExists)
    {
        WithData("name", name);
    }
}

