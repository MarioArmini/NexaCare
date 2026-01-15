using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NexaCare.Database.Shared.Identity;
using NexaCare.Domain.Entities.Addresses;
using NexaCare.Domain.Entities.Identity;
using NexaCare.Domain.Entities.Logging;
using File = NexaCare.Domain.Entities.Files.File;

namespace NexaCare.Database.EntityFrameworkCore;

public class NexaCareDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public NexaCareDbContext(
        DbContextOptions<NexaCareDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<InternalLog> InternalLogs { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<File> Files { get; set; }
}