using Volo.Abp.Settings;

namespace Unhcr.ProtectDataHub.Settings;

public class ProtectDataHubSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ProtectDataHubSettings.MySetting1));
    }
}
