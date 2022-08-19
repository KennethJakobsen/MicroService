using System;
using Gateway.ApiClient.Api;
using Gateway.ApiClient.Client;

namespace MockFrontend
{
    public class ListCustomers : IInteractWithGateway
    {
        private readonly CustomerApi client;

        public ListCustomers(CustomerApi client)
        {
            this.client = client;
        }

        public string Description => "List all customers";

        public async Task ExecuteAsync()
        {
            var customers = await client.ListAllCustomersAsync();

            Console.WriteLine("Id\tName");
            foreach (var customer in customers)
            {
                Console.WriteLine("{0}\t{1}", customer.Id, customer.Name);
            }
        }
    }
}

