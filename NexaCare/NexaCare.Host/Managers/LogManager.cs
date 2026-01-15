using NexaCare.Database.EntityFrameworkCore;
using NexaCare.Domain.Entities.Logging;

namespace NexaCare.Host.Managers;

public class LogManager
{
    private readonly NexaCareDbContext _context;

    public LogManager(NexaCareDbContext context)
    {
        _context = context;
    }

    public async Task CreateInformationLog(string message, string? description)
    {
        if (!string.IsNullOrEmpty(message))
        {
            await _context.InternalLogs.AddAsync(new InternalLog
            {
                Created = DateTime.UtcNow,
                Message = message,
                Description = description,
                IsError = false
            });
        }
    }
    
    public async Task CreateErrorLog(string message, string? description)
    {
        if (!string.IsNullOrEmpty(message))
        {
            await _context.InternalLogs.AddAsync(new InternalLog
            {
                Created = DateTime.UtcNow,
                Message = message,
                Description = description,
                IsError = true
            });
        }
    }
}