using System;
using Rebus.Bus;

namespace EventEmitter
{
	public class MenuRenderer
	{
		private Dictionary<string, ISendEvent> _collection;
		public MenuRenderer(IBus bus)
		{
			_collection = new Dictionary<string, ISendEvent>();
			_collection.Add("a", new CreateNewCustomerSender(bus));
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

