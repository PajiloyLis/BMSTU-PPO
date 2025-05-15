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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new EmployeeDbConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyDbConfiguration());
        modelBuilder.ApplyConfiguration(new EducationDbConfiguration());
    }
}