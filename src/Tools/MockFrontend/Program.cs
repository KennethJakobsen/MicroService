using Customer.Messages;
using Gateway.ApiClient.Api;
using Microsoft.Extensions.DependencyInjection;
using MockFrontend;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;


var collection = new ServiceCollection();
collection.AddRebusHandler<CustomerCreatedEventHandler>();
collection.AddSingleton(new CustomerApi("http://localhost:5010"));
collection.AddSingleton<MenuRenderer>();
collection.AddRebus((configure, provider) => {
    return configure
        .Transport(t => t.UseRabbitMq("amqp://guest:guest@localhost:5672/", "frontend-input"))
        .Logging(c => c.None());

},
onCreated: async bus => {
    await bus.Subscribe<CustomerCreatedEvent>();
});

var provider = collection.BuildServiceProvider();
provider.StartRebus();

var menu = provider.GetService<MenuRenderer>();

await menu.RunMenu();