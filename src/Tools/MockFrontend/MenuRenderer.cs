using System;
using Gateway.ApiClient.Api;
using Rebus.Bus;

namespace MockFrontend
{
	public class MenuRenderer
	{
		private Dictionary<string, IInteractWithGateway> _collection;
		public MenuRenderer(CustomerApi client)
		{
			_collection = new Dictionary<string, IInteractWithGateway>();
			_collection.Add("a", new CreateCustomer(client));
			_collection.Add("b", new ListCustomers(client));
		}

		public async Task RunMenu()
        {
			Console.WriteLine("Please choose below:");
			foreach(var kvp in _collection)
            {
				Console.WriteLine($"{kvp.Key})\t{kvp.Value.Description}");
            }
            

            Console.WriteLine("Enter your choice:");
			var choice = Console.ReadLine();
            Console.Write("\n\n");

            if (_collection.ContainsKey(choice.ToLower()))
				await _collection[choice].ExecuteAsync();
			else
				Console.WriteLine("Invalid choice! Please try again!");
            Console.Write("\n\n");

            await RunMenu();
        }
	}
}

