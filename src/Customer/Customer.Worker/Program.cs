using Customer.Messages;
using Customer.Worker;
using Customer.Worker.Handlers;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AutoRegisterHandlersFromAssemblyOf<CreateNewCustomerHandler>();
        services.AddSingleton(serviceProvider => {
            
            IConfiguration config = serviceProvider.GetRequiredService<IConfiguration>();
            string rabbit = config.GetValue<string>("ConnectionStrings:RabbitMq");
            string input = config.GetValue<string>("Messaging:InputQueue");
            return new WorkerConfiguration(rabbit, input);
        });
        services.AddRebus((configure, provider) =>
        {
            var wc = provider.GetRequiredService<WorkerConfiguration>();
            
            return configure
            .Transport(t => t.UseRabbitMq(wc.RabbitMq, wc.InputQueueName))
            .Options(o => o.SetNumberOfWorkers(5))
            .Routing(r => r.TypeBased().MapAssemblyOf<CreateNewCustomerCommand>(wc.InputQueueName));
        });
        
    });
   var host = builder.Build();

await host.RunAsync();

