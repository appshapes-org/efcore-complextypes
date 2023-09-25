using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class DatabaseContext : DbContextBase
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected DatabaseContext()
    {
    }

    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>().Property(x => x.Id).ValueGeneratedNever();
        builder.Entity<Customer>().ComplexProperty(x => x.Address);
        builder.Entity<Order>().Property(x => x.Id).ValueGeneratedNever();
        builder.Entity<Order>().ComplexProperty(x => x.BillingAddress);
        builder.Entity<Order>().ComplexProperty(x => x.ShippingAddress);
        base.OnModelCreating(builder);
    }
}