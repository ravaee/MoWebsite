using Microsoft.EntityFrameworkCore;
using Mo.Portfolio.Website.Data.Entities;

namespace Mo.Portfolio.Website.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(post => post.Id);
        
        modelBuilder.Entity<Post>()
            .HasOne<Group>(post => post.Group)
            .WithMany(group => group.Posts)
            .HasForeignKey(post => post.GroupId);

        modelBuilder.Entity<Group>().HasKey(group => group.Id);
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Post> Posts { get; init; } = null!;
    public DbSet<Group> Groups { get; init; } = null!;
}