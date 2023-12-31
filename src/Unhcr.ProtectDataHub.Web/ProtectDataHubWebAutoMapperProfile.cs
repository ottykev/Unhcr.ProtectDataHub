using AutoMapper;
using Unhcr.ProtectDataHub.Countries;

namespace Unhcr.ProtectDataHub.Web;

public class ProtectDataHubWebAutoMapperProfile : Profile
{
    public ProtectDataHubWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CountryDto, CreateUpdateCountryDto>();
    }
}
