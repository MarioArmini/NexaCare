using Microsoft.AspNetCore.Mvc;
using NexaCare.Host.Services.Interfaces;

namespace NexaCare.Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressAppService  _addressAppService;

    public AddressController(IAddressAppService addressAppService)
    {
        _addressAppService = addressAppService;
    }

    [HttpGet("GetAllCountries/")]
    public async Task<IActionResult> GetAllCountries()
    {
        var countries = await _addressAppService.GetAllCountries();
        
        return countries.Count > 0 ? Ok(countries) : NotFound();
    }
    
    [HttpGet("GetRegions/{countryId}")]
    public async Task<IActionResult> GetRegions(string countryId)
    {
        var regions = await _addressAppService.GetAllRegions(countryId);
        
        return regions.Count > 0 ? Ok(regions) : NotFound();
    }
    
    [HttpGet("GetCities/{regionId}/")]
    public async Task<IActionResult> GetCities(string regionId)
    {
        var cities = await _addressAppService.GetAllCities(regionId);
        
        return cities.Count > 0 ? Ok(cities) : NotFound();
    }
}