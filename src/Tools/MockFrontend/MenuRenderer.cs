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
		}

		public async Task RunMenu()
        {
			Console.WriteLine("Please choose below:");
			foreach(var kvp in _collection)
            {
				Console.WriteLine($"{kvp.Key})\t\t{kvp.Value.Description}");
            }

			Console.WriteLine("Enter your choice:");
			var choice = Console.ReadLine();

			if (_collection.ContainsKey(choice.ToLower()))
				await _collection[choice].SendAsync();
			else
				Console.WriteLine("Invalid choice! Pleas try again!");
			await RunMenu();
        }
	}
}

