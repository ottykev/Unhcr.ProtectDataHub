using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Countries;
using Unhcr.ProtectDataHub.Regions;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Unhcr.ProtectDataHub.Web.Pages.Countries;

public class CreateModalModel : ProtectDataHubPageModel
{
    [BindProperty]
    public CreateCountryViewModel Country { get; set; }

    public List<SelectListItem> Regions { get; set; }

    private readonly ICountryAppService _countryAppService;

    public CreateModalModel(
        ICountryAppService countryAppService)
    {
        _countryAppService = countryAppService;
    }

    public async Task OnGetAsync()
    {
        Country = new CreateCountryViewModel();

        var regionLookup = await _countryAppService.GetRegionLookupAsync();
        Regions = regionLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await _countryAppService.CreateAsync(
            ObjectMapper.Map<CreateCountryViewModel, CreateCountryDto>(Country)
            );
        return NoContent();
    }

    public class CreateCountryViewModel
    {
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