using Xunit;

namespace Unhcr.ProtectDataHub.EntityFrameworkCore;

[CollectionDefinition(ProtectDataHubTestConsts.CollectionDefinitionName)]
public class ProtectDataHubEntityFrameworkCoreCollection : ICollectionFixture<ProtectDataHubEntityFrameworkCoreFixture>
{

}
