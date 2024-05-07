using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Infrastructure.Persistence;

internal class MotorcycleRentalDbContext(DbContextOptions<MotorcycleRentalDbContext> options) 
    :  IdentityDbContext<User>(options)
{   

    internal DbSet<Motorcycle> Motorcycles { get; set; }
    internal DbSet<RentalPlan> RentalPlans { get; set;}
    internal DbSet<Rent> Rents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Motorcycle>()
        .HasIndex(u => u.LicensePlate)
        .IsUnique();

        modelBuilder.Entity<User>()
            .OwnsOne(u => u.Biker);

        modelBuilder.Entity<User>(entity =>
         entity.Property(e => e.UserType).HasComment($"The unique valid values are:{UserType.Admin}(Admin) and {UserType.Biker}(Biker)"));
            



    }


}
