using System;
using System.Text;
using System.Text.Json;
using Rabbit.Models.Entities;
using Rabbit.Repositories.Interface;
using RabbitMQ.Client;

namespace Rabbit.Repositories
{
	public class RabbitMessageRepository : IRabbitMessageRepository
    {
        
        public void SendMessage(RabbitMessage message)
        {
            var factory = new ConnectionFactory {
                HostName = "localhost",
                UserName = "admin",
                Password = "123456"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "rabbitMessagesQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "rabbitMessagesQueue",
                                 basicProperties: null,
                                 body: body);

        }

    }
}

