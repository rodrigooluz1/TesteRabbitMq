using Microsoft.AspNetCore.Mvc;
using Rabbit.Models.Entities;
using Rabbit.Services.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rabbit.Publisher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveMessageController : ControllerBase
    {
        private readonly IRabbitMessageReceivedService _messageService;

        public ReceiveMessageController(IRabbitMessageReceivedService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public ActionResult<List<RabbitMessage>> ReceiveMessage()
        {
            return _messageService.ReceivedMessage();
            
        }
    }
}


