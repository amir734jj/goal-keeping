using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal;

public sealed class EntityDbContext : IdentityDbContext<User, Role, int>
{
    public EntityDbContext(DbContextOptions<EntityDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Goal>? Goals { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(EntityDbContext).Assembly);
    }
}