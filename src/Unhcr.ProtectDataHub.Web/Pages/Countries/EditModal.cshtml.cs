using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Countries;

namespace Unhcr.ProtectDataHub.Web.Pages.Countries;

public class EditModalModel : ProtectDataHubPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    [BindProperty]
    public CreateUpdateCountryDto Country { get; set; }
    private readonly ICountryAppService _countryAppService;
    public EditModalModel(ICountryAppService countryAppService)
    {
        _countryAppService = countryAppService;
    }
    public async Task OnGetAsync()
    {
        var country = await _countryAppService.GetAsync(Id);
        Country = ObjectMapper.Map<CountryDto, CreateUpdateCountryDto>(countryDto);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await _countryAppService.UpdateAsync(Id, Country);
        return NoContent();
    }
}
