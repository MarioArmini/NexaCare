using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Relic.Database.EntityFrameworkCore;
using Relic.Host.Dto.Addresses;
using Relic.Host.ObjectMapper;
using Relic.Host.Services.Interfaces;

namespace Relic.Host.Services.Addresses;

public class AddressAppService : IAddressAppService
{
    private readonly RelicDbContext _context;
    private readonly IMapper _mapper;

    public AddressAppService(RelicDbContext context,
        IMapper  mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CountryDto>> GetAllCountries()
    {
        var countries = await _context.Countries.ToListAsync();

        return countries.Select(country => _mapper.Map<CountryDto>(country)).ToList();
    }

    public async Task<List<RegionDto>> GetAllRegions(string countryId)
    {
        var regions = await _context.Regions
            .Include(x => x.Country)
            .Where(x => x.Country.Id.ToString() == countryId)
            .ToListAsync();

        return regions.Select(region => _mapper.Map<RegionDto>(region)).ToList();
    }

    public async Task<List<CityDto>> GetAllCities(string regionId)
    {
        var cities = await _context.Cities
            .Include(x => x.Region).ThenInclude(x => x.Country)
            .Where(x => x.Region.Id.ToString() == regionId)
            .ToListAsync();

        return cities.Select(city => _mapper.Map<CityDto>(city)).ToList();
    }
}