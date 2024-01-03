using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Countries;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Unhcr.ProtectDataHub.Web.Pages.Countries;

public class EditModalModel : ProtectDataHubPageModel
{
    [BindProperty]
    public EditCountryViewModel Country { get; set; }

    public List<SelectListItem> Regions { get; set; }

    private readonly ICountryAppService _countryAppService;

    public EditModalModel(ICountryAppService countryAppService)
    {
        _countryAppService = countryAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var countryDto = await _countryAppService.GetAsync(id);
        Country = ObjectMapper.Map<CountryDto, EditCountryViewModel>(countryDto);

        var regionLookup = await _countryAppService.GetRegionLookupAsync();
        Regions = regionLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await _countryAppService.UpdateAsync(
            Country.Id,
            ObjectMapper.Map<EditCountryViewModel, CreateUpdateCountryDto>(Country)
        );

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
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string IsoCode { get; set; } = string.Empty;

        [Required]
        public Cluster ClusterStructure { get; set; } = Cluster.None;
    }
}
