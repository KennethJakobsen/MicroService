using System;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Interfaces;
using Customer.Domain.Model;
using Customer.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure
{
    public class CustomerRepository : IFetchCustomers, IPersistCustomers
    {
        private readonly CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }
        public async Task<CustomerModel> FetchAsync(Guid id)
        {
            return await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveAsync(CustomerModel customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }
    }
}

