using System;
namespace Customer.Worker
{
	public class WorkerConfiguration
	{
        public string RabbitMq { get; set; }
        public string InputQueueName { get; set; }

        public WorkerConfiguration(string rabbitMq, string inputQueueName)
        {
            RabbitMq = rabbitMq;
            InputQueueName = inputQueueName;
        }
    }
}

