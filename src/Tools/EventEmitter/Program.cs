using Customer.Messages;
using EventEmitter;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Routing.TypeBased;

var bus = Configure.With(new BuiltinHandlerActivator())
    .Transport(t => t.UseRabbitMqAsOneWayClient("amqp://guest:guest@localhost:5672/"))
    .Routing(r => r.TypeBased().Map<CreateNewCustomerCommand>("customer-input"))
    .Start();


var renderer = new MenuRenderer(bus);
await renderer.RunMenu();
