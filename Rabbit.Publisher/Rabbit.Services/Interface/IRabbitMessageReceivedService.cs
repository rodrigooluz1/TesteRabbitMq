using System;
using Rabbit.Models.Entities;

namespace Rabbit.Services.Interface
{
	public interface IRabbitMessageReceivedService
	{
        List<RabbitMessage> ReceivedMessage();
	}
}

