using Database.Context.Configuration;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

/// <summary>
/// Database context.
/// </summary>
public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
    {
    }

    protected ProjectDbContext()
    {
    }

    public DbSet<EmployeeDb> EmployeeDb { get; set; }

    public DbSet<CompanyDb> CompanyDb { get; set; }

    public DbSet<EducationDb> EducationDb { get; set; }

    public DbSet<PostDb> PostDb { get; set; }

    public DbSet<PositionDb> PositionDb { get; set; }

    public DbSet<ScoreDb> ScoreDb { get; set; }

    public DbSet<PostHistoryDb> PostHistoryDb { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new EmployeeDbConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyDbConfiguration());
        modelBuilder.ApplyConfiguration(new EducationDbConfiguration());
        modelBuilder.ApplyConfiguration(new PostDbConfiguration());
        modelBuilder.ApplyConfiguration(new PositionDbConfiguration());
        modelBuilder.ApplyConfiguration(new PostHistoryDbConfiguration());
        modelBuilder.ApplyConfiguration(new ScoreDbConfiguration());
    }
}