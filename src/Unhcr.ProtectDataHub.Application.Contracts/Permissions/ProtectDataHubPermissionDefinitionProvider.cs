using Unhcr.ProtectDataHub.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Unhcr.ProtectDataHub.Permissions;

public class ProtectDataHubPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var protectdataHubGroup = context.AddGroup(ProtectDataHubPermissions.GroupName, L("Permission:ProtectDataHub"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProtectDataHubPermissions.MyPermission1, L("Permission:MyPermission1"));
        var countries = protectdataHubGroup.AddPermission(ProtectDataHubPermissions.Countries.Default, L("Permission:Countries"));
        countries.AddChild(ProtectDataHubPermissions.Countries.Create, L("Permission:Countries.Create"));
        countries.AddChild(ProtectDataHubPermissions.Countries.Edit, L("Permission:Countries.Edit"));
        countries.AddChild(ProtectDataHubPermissions.Countries.Delete, L("Permission:Countries.Delete"));
        var persons = protectdataHubGroup.AddPermission(ProtectDataHubPermissions.Persons.Default, L("Permission:Persons"));
        persons.AddChild(ProtectDataHubPermissions.Persons.Create, L("Permission:Persons.Create"));
        persons.AddChild(ProtectDataHubPermissions.Persons.Edit, L("Permission:Persons.Edit"));
        persons.AddChild(ProtectDataHubPermissions.Persons.Delete, L("Permission:Persons.Delete"));
        var regions = protectdataHubGroup.AddPermission(ProtectDataHubPermissions.Regions.Default, L("Permission:Regions"));
        regions.AddChild(ProtectDataHubPermissions.Regions.Create, L("Permission:Regions.Create"));
        regions.AddChild(ProtectDataHubPermissions.Regions.Edit, L("Permission:Regions.Edit"));
        regions.AddChild(ProtectDataHubPermissions.Regions.Delete, L("Permission:Regions.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProtectDataHubResource>(name);
    }
}
