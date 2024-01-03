namespace Unhcr.ProtectDataHub.Permissions;

public static class ProtectDataHubPermissions
{
    public const string GroupName = "ProtectDataHub";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Countries
    {
        public const string Default = GroupName + ".Countries";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Persons
    {
        public const string Default = GroupName + ".Persons";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Regions
    {
        public const string Default = GroupName + ".Regions";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
