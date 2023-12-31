using Unhcr.ProtectDataHub.Samples;
using Xunit;

namespace Unhcr.ProtectDataHub.EntityFrameworkCore.Domains;

[Collection(ProtectDataHubTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProtectDataHubEntityFrameworkCoreTestModule>
{

}
