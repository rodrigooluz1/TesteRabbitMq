using Microsoft.AspNetCore.Mvc;
using Rabbit.Models.Entities;
using Rabbit.Services.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rabbit.Publisher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMessageController : ControllerBase
    {
        private readonly IRabbitMessageService _messageService;

        public RabbitMessageController(IRabbitMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult AddMessage(RabbitMessage message)
        {
            _messageService.SendMessage(message);

            return Ok("Mensagem enviada");
        }
    }
}

