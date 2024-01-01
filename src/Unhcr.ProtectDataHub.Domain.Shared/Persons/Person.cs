namespace Unhcr.ProtectDataHub.Persons;

public enum ClusterAor
{
    None,
    Protection,
    CP,
    GBV,
    HLP,
    MINEACTION
}
public enum Cordination
{
    None,
    National,
    SubNational
}
public enum OrgType
{
    None,
    UN,
    INGO,
    Local_National,
    Other
}
public enum Position
{
    None,
    Coordinator,
    Co_Coordinator,
    Cluster_SupportStaff,
    CoLead,
    Other
}
public enum StaffLevel
{
    None,
    Dedicated,
    DoubleHatting,
    Other
}
public enum DoubleHattingLevel
{
    None,
    Percent1To25,
    Percent26To49,
    Percent50,
    Percent51To75,
    Percent76To99
}
public enum StaffGrade
{
    None,
    P1,
    P2,
    P3,
    P4,
    P5,
    G5,
    G6,
    NOA
}
public enum ContractType
{
    None,
    FTA,
    TA,
    ERT,
    StandbyPartner,
    Other
}