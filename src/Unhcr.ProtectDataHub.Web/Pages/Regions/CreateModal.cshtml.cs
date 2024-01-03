using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Unhcr.ProtectDataHub.Regions;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Unhcr.ProtectDataHub.Web.Pages.Regions;

public class CreateModalModel : ProtectDataHubPageModel
{
    [BindProperty]
    public CreateRegionViewModel Region { get; set; }

    private readonly IRegionAppService _regionAppService;

    public CreateModalModel(IRegionAppService regionAppService)
    {
        _regionAppService = regionAppService;
    }

    public void OnGet()
    {
        Region = new CreateRegionViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateRegionViewModel, CreateRegionDto>(Region);
        await _regionAppService.CreateAsync(dto);
        return NoContent();
    }

    public class CreateRegionViewModel
    {
        [Required]
        [StringLength(RegionConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}