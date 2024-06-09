using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class RentalContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    public RentalContext(DbContextOptions<RentalContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
}
