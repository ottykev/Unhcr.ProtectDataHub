using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Unhcr.ProtectDataHub.Web;

[Dependency(ReplaceServices = true)]
public class ProtectDataHubBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "GPC DataHub";
    public override string LogoUrl => "/logo-light.png";
}
