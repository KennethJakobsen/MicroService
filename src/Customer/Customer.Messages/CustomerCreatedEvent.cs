using System;

namespace Customer.Messages
{
    public class CustomerCreatedEvent
    {
        public Guid Id { get; set; }

        public CustomerCreatedEvent(Guid id)
        {
            Id = id;
        }
    }
}

