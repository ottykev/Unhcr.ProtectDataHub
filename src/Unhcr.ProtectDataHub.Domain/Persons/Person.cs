using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Unhcr.ProtectDataHub.Persons;

public class Person: FullAuditedAggregateRoot<Guid>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ClusterAor Aor { get; set; }
    public Cordination LevelofCordination { get; set; }
    public string DutyStation { get; set; }
    public bool WorkingfromDutyStation { get; set; }
    public OrgType Organization_Type { get; set; }
    public string OrganizationName { get; set; }
    public Position Position { get; set; }
    public StaffLevel Staff { get; set; }
    public DoubleHattingLevel DoubleHatting { get; set; }
    public StaffGrade StaffGrade { get; set; }
    public ContractType ContractType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    private Person()
    {

    }

    internal Person(
               Guid id, string fullName, string email, string phoneNumber, ClusterAor aor, Cordination levelofCordination, string dutyStation, bool workingfromDutyStation, OrgType organization_Type, string organizationName, Position position, StaffLevel staff, DoubleHattingLevel doubleHatting, StaffGrade staffGrade, ContractType contractType, DateTime startDate, DateTime endDate
               )
        : base(id)
    {
        SetFullName(fullName);
        Email = email;
        PhoneNumber = phoneNumber;
        Aor = aor;
        LevelofCordination = levelofCordination;
        DutyStation = dutyStation;
        WorkingfromDutyStation = workingfromDutyStation;
        Organization_Type = organization_Type;
        OrganizationName = organizationName;
        Position = position;
        Staff = staff;
        DoubleHatting = doubleHatting;
        StaffGrade = staffGrade;
        ContractType = contractType;
        StartDate = startDate;
        EndDate = endDate;
    }
    internal Person ChangeName(string fullName)
    {
        SetFullName(fullName);
        return this;
    }
    private void SetFullName(string fullName)
    {
        FullName = Check.NotNullOrWhiteSpace(fullName, nameof(fullName), PersonConsts.MaxFullNameLength);
    }
}
