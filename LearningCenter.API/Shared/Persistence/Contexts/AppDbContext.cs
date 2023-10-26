using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LearningCenter.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CategoryYS> Categories { get; set; }
    public DbSet<TutorialYS> Tutorials { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<CategoryYS>().ToTable("Categories");
        builder.Entity<CategoryYS>().HasKey(p => p.Id);
        builder.Entity<CategoryYS>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CategoryYS>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        
        //Relationships
        builder.Entity<CategoryYS>()
            .HasMany(p => p.TutorialsYs)
            .WithOne(p => p.CategoryYs)
            .HasForeignKey(p => p.CategoryId);
 
        builder.Entity<TutorialYS>().ToTable("Tutorials");
        builder.Entity<TutorialYS>().HasKey(p => p.Id);
        builder.Entity<TutorialYS>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TutorialYS>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<TutorialYS>().Property(p => p.Description).HasMaxLength(120);
 
        //User
        // Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
 
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
        
    }
}