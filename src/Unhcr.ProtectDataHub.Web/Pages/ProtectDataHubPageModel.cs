using Unhcr.ProtectDataHub.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Unhcr.ProtectDataHub.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ProtectDataHubPageModel : AbpPageModel
{
    protected ProtectDataHubPageModel()
    {
        LocalizationResourceType = typeof(ProtectDataHubResource);
    }
}
