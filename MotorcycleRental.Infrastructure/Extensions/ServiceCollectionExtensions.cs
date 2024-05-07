using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            //services.AddIdentityApiEndpoints<User>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<MotorcycleRentalDbContext>();

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            }).AddEntityFrameworkStores<MotorcycleRentalDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultChallengeScheme =
                options.DefaultForbidScheme =
                options.DefaultScheme =
                options.DefaultSignInScheme =
                options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,                    
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
                    )
                };
            });

            services.AddScoped<IMotorcycleRentalSeeder, MotorcycleRentalSeeder>();
            services.AddScoped<IMotorcyclesRepository, MotorcyclesRepository>();
            services.AddScoped<IRentalPlansRepository, RentalPlansRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            
            
        }
    }
}
