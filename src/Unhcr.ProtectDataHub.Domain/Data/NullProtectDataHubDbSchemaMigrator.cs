using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Unhcr.ProtectDataHub.Data;

/* This is used if database provider does't define
 * IProtectDataHubDbSchemaMigrator implementation.
 */
public class NullProtectDataHubDbSchemaMigrator : IProtectDataHubDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
