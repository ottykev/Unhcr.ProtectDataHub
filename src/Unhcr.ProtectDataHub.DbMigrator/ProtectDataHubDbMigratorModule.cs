using Unhcr.ProtectDataHub.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Unhcr.ProtectDataHub.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProtectDataHubEntityFrameworkCoreModule),
    typeof(ProtectDataHubApplicationContractsModule)
    )]
public class ProtectDataHubDbMigratorModule : AbpModule
{
}
