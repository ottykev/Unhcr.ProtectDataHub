using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Countries;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Unhcr.ProtectDataHub.Web.Pages.Countries;

public class EditModalModel : ProtectDataHubPageModel
{
    [BindProperty]
    public EditCountryViewModel Country { get; set; }
    private readonly ICountryAppService _countryAppService;
    public EditModalModel(ICountryAppService countryAppService)
    {
        _countryAppService = countryAppService;
    }
    public async Task OnGetAsync(Guid id)
    {
        var dto = await _countryAppService.GetAsync(id);
        Country = ObjectMapper.Map<CountryDto, EditCountryViewModel>(dto);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditCountryViewModel, UpdateCountryDto>(Country);
        await _countryAppService.UpdateAsync(Country.Id, dto);
        return NoContent();
    }
    public class EditCountryViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [SelectItems(nameof(Regions))]
        [DisplayName("Region")]
        public Guid RegionId { get; set; }

        [Required]
        [StringLength(CountryConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(CountryConsts.MaxCodeLength)]
        public string Code { get; set; } = string.Empty;

        [Required]
        public Cluster ClusterStructure { get; set; } = Cluster.None;
    }
}
