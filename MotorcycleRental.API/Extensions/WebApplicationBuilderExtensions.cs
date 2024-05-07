﻿using Microsoft.OpenApi.Models;
using MotorcycleRental.API.Middlewares;
using MotorcycleRental.Application.Auth.Services;
using Serilog;

namespace MotorcycleRental.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddSwaggerGen(c =>
        //{
        //    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
        //    {
        //        Type = SecuritySchemeType.Http,
        //        Scheme = "Bearer"
        //    });

        //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //    {
        //        {
        //            new OpenApiSecurityScheme
        //            {
        //                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
        //            },
        //            []
        //        }

        //    });
        //});

        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Motorcycle Rental", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<ErrorHandlingMiddleware>();

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
        );

        builder.Services.AddScoped<ITokenService, TokenService>();
    }
}
