using NexaCare.Host.Dto.Addresses;

namespace NexaCare.Host.Services.Interfaces;

public interface IAddressAppService
{
    Task<List<CountryDto>> GetAllCountries();
    Task<List<RegionDto>> GetAllRegions(string countryId);
    Task<List<CityDto>> GetAllCities(string regionId);
}