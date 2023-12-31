using AutoMapper;
using Unhcr.ProtectDataHub.Countries;

namespace Unhcr.ProtectDataHub;

public class ProtectDataHubApplicationAutoMapperProfile : Profile
{
    public ProtectDataHubApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Country, CountryDto>();
        CreateMap<CreateUpdateCountryDto, Country>();
    }
}
