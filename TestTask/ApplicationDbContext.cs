using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask;

public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Order => Set<Order>();

    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=store;Username=YourUsername;Password=YourPassword");
    }
}