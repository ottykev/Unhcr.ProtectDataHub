using AutoMapper;
using Unhcr.ProtectDataHub.Countries;
using Unhcr.ProtectDataHub.Persons;
using Unhcr.ProtectDataHub.Regions;

namespace Unhcr.ProtectDataHub.Web;

public class ProtectDataHubWebAutoMapperProfile : Profile
{
    public ProtectDataHubWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CountryDto, CreateUpdateCountryDto>();
        CreateMap<Pages.Regions.CreateModalModel.CreateRegionViewModel, CreateRegionDto>();
        CreateMap<RegionDto, Pages.Regions.EditModalModel.EditRegionViewModel>();
        CreateMap<Pages.Regions.EditModalModel.EditRegionViewModel, UpdateRegionDto>();
        CreateMap<Pages.Countries.CreateModalModel.CreateCountryViewModel, CreateUpdateCountryDto>();
        CreateMap<CountryDto, Pages.Countries.EditModalModel.EditCountryViewModel>();
        CreateMap<Pages.Countries.EditModalModel.EditCountryViewModel, CreateUpdateCountryDto>();
        CreateMap<Pages.Persons.CreateModalModel.CreatePersonViewModel, CreatePersonDto>();
        CreateMap<PersonDto, Pages.Persons.EditModalModel.EditPersonViewModel>();

    }
}
