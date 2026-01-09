using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Relic.Database.Shared.Identity;
using Relic.Domain.Entities.Addresses;
using Relic.Domain.Entities.Identity;
using Relic.Domain.Entities.Logging;
using File = Relic.Domain.Entities.Files.File;

namespace Relic.Database.EntityFrameworkCore;

public class RelicDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public RelicDbContext(
        DbContextOptions<RelicDbContext> options)
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