using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Unhcr.ProtectDataHub.Web;

[Dependency(ReplaceServices = true)]
public class ProtectDataHubBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ProtectDataHub";
}
