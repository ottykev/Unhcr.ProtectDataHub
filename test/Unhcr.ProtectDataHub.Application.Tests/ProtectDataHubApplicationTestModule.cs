using Volo.Abp.Modularity;

namespace Unhcr.ProtectDataHub;

[DependsOn(
    typeof(ProtectDataHubApplicationModule),
    typeof(ProtectDataHubDomainTestModule)
)]
public class ProtectDataHubApplicationTestModule : AbpModule
{

}
