using System;
using Rabbit.Models.Entities;
using Rabbit.Repositories.Interface;
using Rabbit.Services.Interface;

namespace Rabbit.Services
{
	public class RabbitMessageReceivedService : IRabbitMessageReceivedService
    {
        private readonly IRabbitMessageReceivedRepository _messageRepository;

        public RabbitMessageReceivedService(IRabbitMessageReceivedRepository messageRepository)
		{
            _messageRepository = messageRepository;

        }

        public List<RabbitMessage> ReceivedMessage()
        {
            return _messageRepository.ReceivedMessage();
        }
    }
}

