using AutoMapper;
using Unhcr.ProtectDataHub.Countries;
using Unhcr.ProtectDataHub.Persons;
using Unhcr.ProtectDataHub.Regions;

namespace Unhcr.ProtectDataHub;

public class ProtectDataHubApplicationAutoMapperProfile : Profile
{
    public ProtectDataHubApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Country, CountryDto>();
        CreateMap<CountryDto, CreateCountryDto>();
        CreateMap<CountryDto, UpdateCountryDto>();
        CreateMap<Region, RegionDto>();
        CreateMap<Person, PersonDto>();
        CreateMap<Region, RegionLookupDto>();
        CreateMap<Country, CountryLookupDto>();
    }
}
