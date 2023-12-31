using Microsoft.AspNetCore.Builder;
using Unhcr.ProtectDataHub;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<ProtectDataHubWebTestModule>();

public partial class Program
{
}
