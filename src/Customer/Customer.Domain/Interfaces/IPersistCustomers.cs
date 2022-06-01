using System;
using System.Threading.Tasks;
using Customer.Domain.Model;

namespace Customer.Domain.Interfaces
{
    public interface IPersistCustomers
    {
        Task SaveAsync(CustomerModel customer);
    }
}

