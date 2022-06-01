using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Domain.Model;

namespace Customer.Domain.Interfaces
{
    public interface IFetchCustomers
    {
        Task<CustomerModel> FetchAsync(Guid id);
        Task<List<CustomerModel>> FetchAllAsync();
    }
}

