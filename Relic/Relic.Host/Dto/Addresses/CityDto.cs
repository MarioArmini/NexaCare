namespace Relic.Host.Dto.Addresses;

public class CityDto
{
    public Guid Id { get; set; }
    public RegionDto Region { get; set; }
    public string Name { get; set; }
}