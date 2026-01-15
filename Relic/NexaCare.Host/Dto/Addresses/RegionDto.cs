namespace NexaCare.Host.Dto.Addresses;

public class RegionDto
{
    public Guid Id { get; set; }
    public CountryDto Country { get; set; }
    public string Name { get; set; }
}