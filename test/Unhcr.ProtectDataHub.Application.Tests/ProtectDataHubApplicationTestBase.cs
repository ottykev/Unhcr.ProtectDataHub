using Volo.Abp.Modularity;

namespace Unhcr.ProtectDataHub;

public abstract class ProtectDataHubApplicationTestBase<TStartupModule> : ProtectDataHubTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
