namespace NexaCare.Domain.Entities.Logging;

public class InternalLog
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public required string Message { get; set; }
    public string? Description { get; set; }
    public required bool IsError { get; set; }
}