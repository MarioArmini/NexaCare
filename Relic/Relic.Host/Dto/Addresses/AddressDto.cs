namespace Relic.Host.Dto.Addresses;

public class AddressDto
{
    public Guid Id { get; set; }
    public CityDto City { get; set; }
    public string Name { get; set; }
    public string PostalCode { get; set; }
}