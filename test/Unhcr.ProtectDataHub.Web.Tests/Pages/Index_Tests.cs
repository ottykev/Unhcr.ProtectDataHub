using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Unhcr.ProtectDataHub.Pages;

public class Index_Tests : ProtectDataHubWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
