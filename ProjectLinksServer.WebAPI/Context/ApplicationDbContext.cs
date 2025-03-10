using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Project> Projects { get; set; } = default!;
    public DbSet<Link> Links { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
