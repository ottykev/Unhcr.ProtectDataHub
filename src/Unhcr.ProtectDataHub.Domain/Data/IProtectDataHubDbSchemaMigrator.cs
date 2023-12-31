using System.Threading.Tasks;

namespace Unhcr.ProtectDataHub.Data;

public interface IProtectDataHubDbSchemaMigrator
{
    Task MigrateAsync();
}
