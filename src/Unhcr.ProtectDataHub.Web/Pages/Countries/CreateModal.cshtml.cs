using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Countries;

namespace Unhcr.ProtectDataHub.Web.Pages.Countries
{
    public class CreateModalModel : ProtectDataHubPageModel
    {
        [BindProperty]
        public CreateUpdateCountryDto Country { get; set; }
        private readonly ICountryAppService _countryAppService;
        public CreateModalModel(ICountryAppService countryAppService)
        {
            _countryAppService = countryAppService;
        }

        public void OnGet()
        {
            Country = new CreateUpdateCountryDto();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _countryAppService.CreateAsync(Country);
            return NoContent();
        }
    }
}
