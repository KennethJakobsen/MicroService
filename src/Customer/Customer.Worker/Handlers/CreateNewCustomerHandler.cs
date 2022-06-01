using System;
using Customer.Domain.Interfaces;
using Customer.Infrastructure;
using Customer.Messages;
using Rebus.Handlers;

namespace Customer.Worker.Handlers
{
    public class CreateNewCustomerHandler : IHandleMessages<CreateNewCustomerCommand>
    {
        private readonly ILogger<Worker> logger;
        private readonly IPersistCustomers repo;

        public async Task Handle(CreateNewCustomerCommand message)
        {
            await repo.SaveAsync(new Domain.Model.CustomerModel()
            {
                Id = message.Id,
                Name = message.Name
            });
        }

        public CreateNewCustomerHandler(ILogger<Worker> logger, IPersistCustomers repo)
		{
            this.logger = logger;
            this.repo = repo;
        }
	}
}

