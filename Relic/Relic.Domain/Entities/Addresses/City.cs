namespace Relic.Domain.Entities.Addresses;

public class City
{
    public Guid Id { get; set; }
    public required Region Region { get; set; }
    public required string Name { get; set; }
}