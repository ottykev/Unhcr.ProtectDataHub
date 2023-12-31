using System;
using System.Collections.Generic;
using System.Text;
using Unhcr.ProtectDataHub.Localization;
using Volo.Abp.Application.Services;

namespace Unhcr.ProtectDataHub;

/* Inherit your application services from this class.
 */
public abstract class ProtectDataHubAppService : ApplicationService
{
    protected ProtectDataHubAppService()
    {
        LocalizationResource = typeof(ProtectDataHubResource);
    }
}
