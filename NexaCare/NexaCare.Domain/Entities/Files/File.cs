namespace NexaCare.Domain.Entities.Files;

public class File : BaseEntity
{
    public required string FileName { get; set; }
    public required string Extension { get; set; }
    public required string MimeType { get; set; }
    public required long Size { get; set; }
    public required byte[] Data { get; set; }
}