using System;
using Customer.Messages;
using Rebus.Handlers;

namespace Customer.Worker.Handlers
{
    public class CreateNewCustomerHandler : IHandleMessages<CreateNewCustomerCommand>
    {
        private readonly ILogger<Worker> logger;

        public Task Handle(CreateNewCustomerCommand message)
        {
            logger.LogInformation("Message Received - Name: " + message.Name);
            return Task.CompletedTask;
        }

        public CreateNewCustomerHandler(ILogger<Worker> logger)
		{
            this.logger = logger;
        }
	}
}

