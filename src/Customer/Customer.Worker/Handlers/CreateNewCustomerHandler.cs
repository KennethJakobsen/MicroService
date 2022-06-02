using System;
using Customer.Domain.Interfaces;
using Customer.Infrastructure;
using Customer.Messages;
using Rebus.Bus;
using Rebus.Handlers;

namespace Customer.Worker.Handlers
{
    public class CreateNewCustomerHandler : IHandleMessages<CreateNewCustomerCommand>
    {
        private readonly ILogger<Worker> logger;
        private readonly IPersistCustomers repo;
        private readonly IBus bus;

        public async Task Handle(CreateNewCustomerCommand message)
        {
            await repo.SaveAsync(new Domain.Model.CustomerModel()
            {
                Id = message.Id,
                Name = message.Name
            });
            await bus.Publish(new CustomerCreatedEvent(message.Id));
        }

        public CreateNewCustomerHandler(ILogger<Worker> logger, IPersistCustomers repo, IBus bus)
		{
            this.logger = logger;
            this.repo = repo;
            this.bus = bus;
        }
	}
}

