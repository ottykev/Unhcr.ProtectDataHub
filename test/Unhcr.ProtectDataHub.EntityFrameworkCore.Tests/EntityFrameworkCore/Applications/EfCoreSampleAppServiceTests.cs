using Unhcr.ProtectDataHub.Samples;
using Xunit;

namespace Unhcr.ProtectDataHub.EntityFrameworkCore.Applications;

[Collection(ProtectDataHubTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProtectDataHubEntityFrameworkCoreTestModule>
{

}
