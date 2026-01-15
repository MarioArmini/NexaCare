using AutoMapper;
using NexaCare.Domain.Entities.Addresses;
using NexaCare.Host.Dto.Addresses;

namespace NexaCare.Host.ObjectMapper;

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