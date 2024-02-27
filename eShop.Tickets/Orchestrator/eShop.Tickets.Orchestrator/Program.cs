using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Saga.Domain.Entities;
using Saga.Domain.StateMachines;
using Saga.Infrastructure;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace eShop.Tickets.Orchestrator
{
    public class Program
    {
        static bool? _isRunningInContainer;

        static bool IsRunningInContainer =>
            _isRunningInContainer ??= bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out var inContainer) && inContainer;

        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(config =>
                    {
                        config.AddDelayedMessageScheduler();

                        config.SetKebabCaseEndpointNameFormatter();

                        config.AddSagaStateMachine<TicketOrderStateMachine, TicketOrderState>()
                            .EntityFrameworkRepository(repository =>
                            {
                                repository.ConcurrencyMode = ConcurrencyMode.Pessimistic;
                                repository.AddDbContext<DbContext, SagaContext>((provider, builder) =>
                                {
                                    builder.UseSqlServer("Data Source=localhost;Initial Catalog=Saga;User Id=srvc_saga_s;Password=saga1;MultipleActiveResultSets=True;Encrypt=True;Trust Server Certificate=True");
                                });
                            });

                        var entryAssembly = Assembly.GetEntryAssembly();

                        config.AddConsumers(entryAssembly);
                        config.AddSagaStateMachines(entryAssembly);
                        config.AddSagas(entryAssembly);
                        config.AddActivities(entryAssembly);

                        config.UsingRabbitMq((context, cfg) =>
                        {
                            if (IsRunningInContainer)
                                cfg.Host("rabbitmq");

                            cfg.UseDelayedMessageScheduler();

                            cfg.ConfigureEndpoints(context);
                        });
                    });
                });
    }
}
