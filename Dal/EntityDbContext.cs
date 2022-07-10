using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal;

public class EntityDbContext : IdentityDbContext<User, Role, int>
{
    public EntityDbContext(DbContextOptions<EntityDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Goal> Goals { get; set; }

}