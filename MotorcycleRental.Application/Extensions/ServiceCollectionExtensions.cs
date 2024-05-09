﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MotorcycleRental.Application.Auth.Services;
using MotorcycleRental.Application.Users;

namespace MotorcycleRental.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {

            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
           
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
            services.AddAutoMapper(applicationAssembly);

            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();

            services.AddScoped<IUserContext,UserContext>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddHttpContextAccessor();
        }
    }
}
