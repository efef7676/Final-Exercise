using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Common;

namespace BL
{
    public class CommunicationWithRabbitMQ
    {
        private ConnectionFactory Factory { get; set; }

        public CommunicationWithRabbitMQ()
        {
            Factory = new ConnectionFactory();
        }

        public void PublishMessage(string body)
        {
            using (var connection = Factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var message = Encoding.UTF8.GetBytes(body);
                    channel.BasicPublish("", ConfigorationValues.QueueName, null, message);
                }
            }
        }

    }
}
