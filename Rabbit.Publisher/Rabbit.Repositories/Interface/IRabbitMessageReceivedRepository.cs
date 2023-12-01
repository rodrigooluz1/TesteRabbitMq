using System;
using Rabbit.Models.Entities;

namespace Rabbit.Repositories.Interface
{
	public interface IRabbitMessageReceivedRepository
	{
        List<RabbitMessage> ReceivedMessage();
	}
}

