using Microsoft.EntityFrameworkCore;

namespace Permission.Infrastructure.Database;

public sealed class PermissionDbContext(DbContextOptions<PermissionDbContext> options)
    : DbContext(options)
{
    public DbSet<Domain.Entities.Permission> Permission { get; set; }

    public DbSet<Domain.Entities.PermissionType> PermissionType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermissionDbContext).Assembly);
    }
}