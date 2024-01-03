using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Unhcr.ProtectDataHub.Persons;

public class PersonDto: AuditedEntityDto<Guid>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid CountryId { get; set; }
    public string CountryName { get; set; }
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
    public bool IsActive { get; set; }
}
