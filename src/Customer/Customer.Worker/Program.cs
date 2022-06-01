using Customer.Domain.Interfaces;
using Customer.Infrastructure;
using Customer.Infrastructure.EF.Contexts;
using Customer.Messages;
using Customer.Worker;
using Customer.Worker.Handlers;
using Microsoft.EntityFrameworkCore;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((Action<IServiceCollection>)(services =>
{
    services.AddHostedService<Worker>();
    services.AddTransient<IPersistCustomers, CustomerRepository>();
    services.AutoRegisterHandlersFromAssemblyOf<CreateNewCustomerHandler>();
    RegisterExternals(services);
}));
   var host = builder.Build();

await host.RunAsync();

static void RegisterExternals(IServiceCollection services)
{
    
    IConfiguration config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

    string rabbit = config.GetValue<string>("ConnectionStrings:RabbitMq");
    string sql = config.GetValue<string>("ConnectionStrings:SqlServer");
    string input = config.GetValue<string>("Messaging:InputQueue");
    var wc = new WorkerConfiguration(rabbit, input, sql);

    services.AddRebus((configure, provider) =>
    {
        return configure
        .Transport(t => t.UseRabbitMq(wc.RabbitMq, wc.InputQueueName))
        .Options(o => o.SetNumberOfWorkers(5))
        .Routing(r => r.TypeBased().MapAssemblyOf<CreateNewCustomerCommand>(wc.InputQueueName));
    });

    services.AddDbContext<CustomerContext>(options =>
    {
        options.UseSqlServer(wc.SqlServer, b => b.MigrationsAssembly(typeof(Program).Assembly.FullName));
    });
}