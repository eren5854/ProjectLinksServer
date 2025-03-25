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
        builder.Entity<Category>()
            .HasMany(x => x.SubCategories)
            .WithOne(x => x.MainCategory)
            .HasForeignKey(x => x.MainCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Project>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Projects)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Link>()
            .HasOne(x => x.Project)
            .WithMany(x => x.Links)
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
