using System;
using Rabbit.Models.Entities;
using Rabbit.Repositories.Interface;
using Rabbit.Services.Interface;

namespace Rabbit.Services
{
	public class RabbitMessageService : IRabbitMessageService
    {
        private readonly IRabbitMessageRepository _messageRepository;

        public RabbitMessageService(IRabbitMessageRepository messageRepository)
		{
            _messageRepository = messageRepository;

        }

        public void SendMessage(RabbitMessage message)
        {
            _messageRepository.SendMessage(message);
        }
    }
}

