namespace NexaCare.Domain.Entities.Addresses;

public class Region
{
    public Guid Id { get; set; }
    public required Country Country { get; set; }
    public required string Name { get; set; }
}