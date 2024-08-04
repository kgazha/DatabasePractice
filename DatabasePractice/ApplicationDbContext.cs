using DatabasePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabasePractice;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    
    public ApplicationDbContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=SimpleApiDb;Username=postgres;Password=admin;");
    }
}