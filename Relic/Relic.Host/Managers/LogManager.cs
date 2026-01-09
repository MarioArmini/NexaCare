using Relic.Database.EntityFrameworkCore;
using Relic.Domain.Entities.Logging;

namespace Relic.Host.Managers;

public class LogManager
{
    private readonly RelicDbContext _context;

    public LogManager(RelicDbContext context)
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