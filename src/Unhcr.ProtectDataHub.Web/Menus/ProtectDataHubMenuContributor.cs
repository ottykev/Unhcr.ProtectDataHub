using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Localization;
using Unhcr.ProtectDataHub.MultiTenancy;
using Unhcr.ProtectDataHub.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Unhcr.ProtectDataHub.Web.Menus;

public class ProtectDataHubMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<ProtectDataHubResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ProtectDataHubMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        context.Menu.AddItem(
    new ApplicationMenuItem(
        "ProtectDataHub",
        l["Menu:ProtectDataHub"],
        icon: "fa fa-diagram-project"
    ).AddItem(
        new ApplicationMenuItem(
            "ProtectDataHub.Countries",
            l["Menu:Countries"],
            url: "/Countries"
        ).RequirePermissions(ProtectDataHubPermissions.Countries.Default)
    )
);


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
