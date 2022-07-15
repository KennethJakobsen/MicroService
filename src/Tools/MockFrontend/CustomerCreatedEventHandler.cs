using System;
using Customer.Messages;
using Gateway.ApiClient.Api;
using Rebus.Handlers;

namespace MockFrontend
{
	public class CustomerCreatedEventHandler : IHandleMessages<CustomerCreatedEvent>
	{
        private readonly CustomerApi client;

        public CustomerCreatedEventHandler(CustomerApi client)
		{
            this.client = client;
        }

        public async Task Handle(CustomerCreatedEvent message)
        {
            Console.WriteLine("Customer created: " + message.Id.ToString());
            var cust = await client.GetCustomerByIdAsync(message.Id.ToString());

            Console.WriteLine($"Name: {cust.Name}, Id: {cust.Id}");

        }
    }
}

