using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unhcr.ProtectDataHub.Persons;

public class UpdatePersonDto
{
    [Required]
    [StringLength(PersonConsts.MaxFullNameLength)]
    public string FullName { get; set; } = string.Empty;
    [Required]
    [StringLength(PersonConsts.MaxEmailLength)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [StringLength(PersonConsts.MaxPhoneNumberLength)]
    public string PhoneNumber { get; set; } = string.Empty;
    public Guid CountryId { get; set; }
    [Required]
    public ClusterAor Aor { get; set; }
    [Required]
    public Cordination LevelofCordination { get; set; }
    [Required]
    [StringLength(PersonConsts.MaxDutyStationLength)]
    public string DutyStation { get; set; } = string.Empty;
    [Required]
    public bool WorkingfromDutyStation { get; set; }
    [Required]
    public OrgType Organization_Type { get; set; }
    [Required]
    [StringLength(PersonConsts.MaxOrganizationNameLength)]
    public string OrganizationName { get; set; } = string.Empty;
    [Required]
    public Position Position { get; set; }
    [Required]
    public StaffLevel Staff { get; set; }
    [Required]
    public DoubleHattingLevel DoubleHatting { get; set; }
    [Required]
    public StaffGrade StaffGrade { get; set; }
    [Required]
    public ContractType ContractType { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public bool IsActive { get; set; }
}
