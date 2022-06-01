using System;
namespace Customer.Worker
{
	public class WorkerConfiguration
	{
        public string RabbitMq { get; set; }
        public string SqlServer { get; set; }
        public string InputQueueName { get; set; }

        public WorkerConfiguration(string rabbitMq, string inputQueueName, string sqlServer)
        {
            RabbitMq = rabbitMq;
            InputQueueName = inputQueueName;
            SqlServer = sqlServer;
        }
    }
}

