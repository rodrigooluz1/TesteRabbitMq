using System;
using Rabbit.Models.Entities;

namespace Rabbit.Services.Interface
{
	public interface IRabbitMessageService
	{
		void SendMessage(RabbitMessage message);
	}
}

