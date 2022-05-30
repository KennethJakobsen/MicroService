using System;
namespace Customer.Messages
{
	public class CreateNewCustomerCommand
	{
        public CreateNewCustomerCommand(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}

