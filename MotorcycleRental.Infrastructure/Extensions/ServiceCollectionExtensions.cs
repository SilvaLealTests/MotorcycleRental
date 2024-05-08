﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;
using MotorcycleRental.Infrastructure.Persistence;
using MotorcycleRental.Infrastructure.Repositories;
using MotorcycleRental.Infrastructure.Seeders;

namespace MotorcycleRental.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {

            var connectionString = configuration.GetConnectionString("MotorcycleRentDb");
            services.AddDbContext<MotorcycleRentalDbContext>(options => options.UseNpgsql(connectionString));

            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MotorcycleRentalDbContext>();
            
            services.AddScoped<IMotorcycleRentalSeeder, MotorcycleRentalSeeder>();
            services.AddScoped<IMotorcyclesRepository, MotorcyclesRepository>();
            services.AddScoped<IRentPlansRepository, RentPlansRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRentsRepository, RentsRepository>();
            services.AddScoped<IBikersRepository, BikersRepository>(); 

            
            
        }
    }
}
