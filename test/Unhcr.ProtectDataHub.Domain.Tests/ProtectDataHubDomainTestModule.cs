using Volo.Abp.Modularity;

namespace Unhcr.ProtectDataHub;

[DependsOn(
    typeof(ProtectDataHubDomainModule),
    typeof(ProtectDataHubTestBaseModule)
)]
public class ProtectDataHubDomainTestModule : AbpModule
{

}
