using Customer.Domain.Interfaces;
using Customer.Infrastructure;
using Customer.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IFetchCustomers, CustomerRepository>();
RegisterExternals(builder);

static void RegisterExternals(WebApplicationBuilder builder)
{
    string sql = builder.Configuration.GetValue<string>("ConnectionStrings:SqlServer");
    Console.WriteLine(sql);
    builder.Services.AddDbContext<CustomerContext>(options =>
    {
        options.UseSqlServer(sql, b => b.MigrationsAssembly(typeof(Program).Assembly.FullName));
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

