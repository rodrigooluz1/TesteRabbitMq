using System;
using System.Text;
using System.Text.Json;
using Rabbit.Models.Entities;
using Rabbit.Repositories.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Rabbit.Repositories
{
	public class RabbitMessageReceivedRepository : IRabbitMessageReceivedRepository
	{
		
        public List<RabbitMessage> ReceivedMessage()
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
            
            var consumer = new EventingBasicConsumer(channel);


            List<RabbitMessage> messagesList = new List<RabbitMessage>();

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);


                RabbitMessage message = JsonSerializer.Deserialize<RabbitMessage>(json);

                messagesList.Add(new RabbitMessage { Id = message.Id, Text = message.Text, Title = message.Title });


            };


            channel.BasicConsume(queue: "rabbitMessagesQueue",
                                 autoAck: true,
                                 consumer: consumer);


            return messagesList;


        }

    }
}

