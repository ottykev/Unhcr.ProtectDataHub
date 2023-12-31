using Unhcr.ProtectDataHub.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Unhcr.ProtectDataHub.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProtectDataHubController : AbpControllerBase
{
    protected ProtectDataHubController()
    {
        LocalizationResource = typeof(ProtectDataHubResource);
    }
}
