using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        modelBuilder.Entity<User>()
            .OwnsOne(u => u.Biker);



    }


}
