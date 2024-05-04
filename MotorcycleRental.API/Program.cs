using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Infrastructure.Extensions;
using MotorcycleRental.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

//Seeder execution
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IMotorcycleRentalSeeder>();
await seeder.Seed();

app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
