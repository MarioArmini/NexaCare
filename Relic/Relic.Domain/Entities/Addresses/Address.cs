namespace Relic.Domain.Entities.Addresses;

public class Address
{
    public Guid Id { get; set; }
    public required City City { get; set; }
    public required string Name { get; set; }
    public required string PostalCode { get; set; }
}