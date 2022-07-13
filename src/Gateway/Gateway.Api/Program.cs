
using Customer.Messages;
using Rebus.Config;
using Rebus.Routing.TypeBased;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRebus((configure, provider) => {
    return configure
        .Transport(t => t.UseRabbitMqAsOneWayClient("amqp://guest:guest@rabbitmq:5672/"))
        .Routing(r => r.TypeBased().MapAssemblyOf<CreateNewCustomerCommand>("customer-input"));
});
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

