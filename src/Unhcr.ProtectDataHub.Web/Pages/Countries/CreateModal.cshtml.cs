using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Countries;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Unhcr.ProtectDataHub.Web.Pages.Countries
{
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
                ObjectMapper.Map<CreateCountryViewModel, CreateUpdateCountryDto>(Country)
                );
            return NoContent();
        }

        public class CreateCountryViewModel
        {
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
}
