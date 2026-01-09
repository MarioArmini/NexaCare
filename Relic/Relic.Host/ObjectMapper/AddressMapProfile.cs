using AutoMapper;
using Relic.Domain.Entities.Addresses;
using Relic.Host.Dto.Addresses;

namespace Relic.Host.ObjectMapper;

public class AddressMapProfile : Profile
{
    public AddressMapProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<Region, RegionDto>();
        CreateMap<City, CityDto>();
        CreateMap<Address, AddressDto>();
    }
}