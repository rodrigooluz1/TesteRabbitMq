using System;
using Rabbit.Models.Entities;

namespace Rabbit.Repositories.Interface
{
	public interface IRabbitMessageRepository
	{
        void SendMessage(RabbitMessage message);
    }
}

