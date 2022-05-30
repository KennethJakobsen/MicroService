using System;
using Customer.Messages;
using Rebus.Bus;

namespace EventEmitter
{
	public class CreateNewCustomerSender : ISendEvent
	{
        private readonly IBus _bus;

        public CreateNewCustomerSender(IBus bus)
		{
            _bus = bus;
        }

        public string Description => "Create a new customer";

        public async Task SendAsync()
        {
            Console.WriteLine("Please enter Customer name:");
            var name = Console.ReadLine();

            await _bus.Send(new CreateNewCustomerCommand(name, Guid.NewGuid()));
        }
    }
}

