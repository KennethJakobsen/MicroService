using Customer.Domain.Model;
using Customer.Infrastructure;
using Customer.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace Customer.Tests.Unit;

[TestClass]
public class CustomerRepositoryTests
{
    private DbContextOptions<CustomerContext> options;
    private const string dbName = "customers";

    [TestInitialize]
    public async Task Setup()
    {
        options = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(dbName)
            .Options;


        using (var context = new CustomerContext(options))
        {

            try {
                await context.Customers.AddAsync(new CustomerModel() { Id = new Guid("dab3c101-5467-4d15-bdc8-3d5d7bab6169"), Name = "Test1" });
                await context.Customers.AddAsync(new CustomerModel() { Id = new Guid("ffb96215-8a44-4659-baf1-6415203098f8"), Name = "Test2" });
                await context.Customers.AddAsync(new CustomerModel() { Id = new Guid("763abd67-ff99-4040-abd7-833a89d5d539"), Name = "Test3" });
                await context.Customers.AddAsync(new CustomerModel() { Id = new Guid("08408b19-97d7-444c-b375-10f4662ef4a8"), Name = "Test4" });
            
                await context.SaveChangesAsync();
            }
            catch { }
        }



    }
    [TestMethod]
    public async Task CanGetSingleCustomerById()
    {
        using(var context = new CustomerContext(options))
        {
            var repo = new CustomerRepository(context);
            var result = await repo.FetchAsync(new Guid("dab3c101-5467-4d15-bdc8-3d5d7bab6169"));

            result.Name.ShouldBe("Test1");
        }
    }

    [TestMethod]
    public async Task DoesNotGetCustomerWithInvalidId()
    {
        using (var context = new CustomerContext(options))
        {
            var repo = new CustomerRepository(context);
            var result = await repo.FetchAsync(new Guid("dab3c103-5467-4d15-bdc8-3d5d7bab6169"));

            result.ShouldBe(null);
        }
    }
}
