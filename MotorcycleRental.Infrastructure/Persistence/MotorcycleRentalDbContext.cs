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

        //**modelBuilder.Entity<Motorcycle>(entity =>
        //{
        //    entity.HasKey(e => e.Id);
        //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
        //    entity.Property(e => e.Year).IsRequired();
        //    entity.Property(e => e.LicensePlate).IsRequired();
        //    entity.Property(e => e.Model).IsRequired();
        //}
        //); 

        modelBuilder.Entity<User>()
            .OwnsOne(u => u.Biker);



    }


}
