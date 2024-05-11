using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MotorcycleRentMessageBrokerConsumer1.Domain;
using MotorcycleRentMessageBrokerConsumer1.Domain.Repositories;
using MotorcycleRentMessageBrokerConsumer1.Infrastructure.Persistence;
using MotorcycleRentMessageBrokerConsumer1.Infrastructure.Repositories;
using MotorcycleRentMessageBrokerConsumer1.Infrastructure.Services;
using Serilog;

namespace MotorcycleRentMessageBrokerConsumer1;

class Program
{
    public delegate RabbitMQConsumer RabbitMQConsumerFactory(string hostname, string queueName, string username, string password);

    static void Main(string[] args)
    {
        //Setting Configuration File
        var builder = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();

        //Setting Logger
       Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();


        // Configuração de DI
        var services = new ServiceCollection()
            .AddDbContext<MortorcycleRentMessageBrokerCusomer1DbContext>(options =>
                options.UseNpgsql(configuration["ConnectionStrings:MotorcycleRentDb"]))
            .AddSingleton<IMotorcycle2024Repository, Motorcycle2024Repository>()
            .AddSingleton<IEmailService, EmailService>()
            .AddTransient<RabbitMQConsumer>(provider =>
                new RabbitMQConsumer(provider.GetRequiredService<IMotorcycle2024Repository>(), 
                provider.GetRequiredService<IEmailService>()
                //,provider.GetRequiredService<ILogger<RabbitMQConsumer>>(), 
                "localhost", "fila_moto2024", "guest", "guest"))
            .AddTransient<RabbitMQConsumerFactory>(provider =>
                (string hostname, string queueName, string username, string password) => provider.GetRequiredService<RabbitMQConsumer>());  // Registro do factory

        var provider = services.BuildServiceProvider();

        // Obter DbContext
        using (var context = provider.GetRequiredService<MortorcycleRentMessageBrokerCusomer1DbContext>())
        {
            // Aplica as migrations
            DatabaseInitializer.MigrateDatabase(context);
        

        // Usando o factory para obter o consumidor
        var rabbitMQConsumerFactory = provider.GetRequiredService<RabbitMQConsumerFactory>();
        var rabbitMQConsumer = rabbitMQConsumerFactory("localhost", "fila_moto2024", "guest", "guest");

        // Iniciar o consumidor
        rabbitMQConsumer.Start();

        }
    }
}