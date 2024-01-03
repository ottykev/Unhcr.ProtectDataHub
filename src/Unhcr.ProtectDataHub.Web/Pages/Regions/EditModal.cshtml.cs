using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Regions;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Unhcr.ProtectDataHub.Web.Pages.Regions;

public class EditModalModel : ProtectDataHubPageModel
{
    [BindProperty]
    public EditRegionViewModel Region { get; set; }
    private readonly IRegionAppService _regionAppService;
    public EditModalModel(IRegionAppService regionAppService)
    {
        _regionAppService = regionAppService;
    }
    public async Task OnGetAsync(Guid id)
    {
        var regionDto = await _regionAppService.GetAsync(id);
        Region = ObjectMapper.Map<RegionDto, EditRegionViewModel>(regionDto);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await _regionAppService.UpdateAsync(Region.Id, ObjectMapper.Map<EditRegionViewModel, UpdateRegionDto>(Region)
            );
        return NoContent();
    }
    public class EditRegionViewModel : UpdateRegionDto
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Required]
        [StringLength(RegionConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;
    }
}