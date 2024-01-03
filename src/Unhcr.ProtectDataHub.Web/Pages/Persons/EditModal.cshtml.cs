using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Persons;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Unhcr.ProtectDataHub.Web.Pages.Persons;

public class EditModalModel : ProtectDataHubPageModel
{
    [BindProperty]
    public EditPersonViewModel Person { get; set; }
    private readonly IPersonAppService _personAppService;
    public EditModalModel(IPersonAppService personAppService)
    {
        _personAppService = personAppService;
    }
    public async Task OnGetAsync(Guid id)
    {
        var dto = await _personAppService.GetAsync(id);
        Person = ObjectMapper.Map<PersonDto, EditPersonViewModel>(dto);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditPersonViewModel, UpdatePersonDto>(Person);
        await _personAppService.UpdateAsync(Person.Id, dto);
        return NoContent();
    }
    public class EditPersonViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [SelectItems(nameof(Countries))]
        [DisplayName("Country")]
        public Guid CountryId { get; set; }
        [Required]
        [StringLength(PersonConsts.MaxFullNameLength)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(PersonConsts.MaxEmailLength)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(PersonConsts.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [DisplayName("AOR")]
        public ClusterAor Aor { get; set; } = ClusterAor.None;
        [Required]
        [DisplayName("Level of Coordination")]
        public Cordination LevelofCordination { get; set; } = Cordination.None;
        [Required]
        [StringLength(PersonConsts.MaxDutyStationLength)]
        [DisplayName("Duty Station")]
        public string DutyStation { get; set; } = string.Empty;
        [Required]
        [DisplayName("Working from Duty Station")]
        public bool WorkingfromDutyStation { get; set; }
        [Required]
        [DisplayName("Organization Type")]
        public OrgType Organization_Type { get; set; } = OrgType.None;
        [Required]
        [StringLength(PersonConsts.MaxOrganizationNameLength)]
        [DisplayName("Organization Name")]
        public string OrganizationName { get; set; } = string.Empty;
        [Required]
        [DisplayName("Position")]
        public Position Position { get; set; } = Position.None;
        [Required]
        [DisplayName("Staff Level")]
        public StaffLevel Staff { get; set; } = StaffLevel.None;
        [Required]
        [DisplayName("Double Hatting Level")]
        public DoubleHattingLevel DoubleHatting { get; set; } = DoubleHattingLevel.None;
        [Required]
        [DisplayName("Staff Grade")]
        public StaffGrade StaffGrade { get; set; }= StaffGrade.None;
        [Required]
        [DisplayName("Contract Type")]
        public ContractType ContractType { get; set; }= ContractType.None;
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }= DateTime.Now;
        [Required]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }= DateTime.Now;
        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

    }
}
