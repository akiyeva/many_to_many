using ManyToMany.Configurations;
using ManyToMany.Models;
using ManyToMany.Utils;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ManyToMany.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Constants.connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}