using System;
using Gateway.ApiClient.Api;

namespace MockFrontend
{
	public class CreateCustomer : IInteractWithGateway
	{
        private readonly CustomerApi client;

        public CreateCustomer(CustomerApi client)
		{
            this.client = client;
        }

        public string Description => "Create new customer";

        public async Task ExecuteAsync()
        {
            Console.WriteLine("Please enter customer name:");

            var name = Console.ReadLine();

            await client.CreateNewCustomerAsync(name);
        }
    }
}

