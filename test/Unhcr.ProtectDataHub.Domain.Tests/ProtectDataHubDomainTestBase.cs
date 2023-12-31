using Volo.Abp.Modularity;

namespace Unhcr.ProtectDataHub;

/* Inherit from this class for your domain layer tests. */
public abstract class ProtectDataHubDomainTestBase<TStartupModule> : ProtectDataHubTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
