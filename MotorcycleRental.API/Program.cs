using MotorcycleRental.API.Middlewares;
using MotorcycleRental.Application.Extensions;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Infrastructure.Extensions;
using MotorcycleRental.Infrastructure.Seeders;
using MotorcycleRental.API.Extensions; 

try
{


var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

//Seeder execution
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IMotorcycleRentalSeeder>();
await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

    app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

    app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
}
catch (Exception)
{

    throw;
}