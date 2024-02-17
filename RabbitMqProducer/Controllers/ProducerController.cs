using Microsoft.AspNetCore.Mvc;
using RabbitMqConsumer.ServiceBus;

namespace RabbitMqProducer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProducerController(IMessageProducer messageProducer) : ControllerBase
    {
        private const string QUEUE_NAME = "TestQueue";

        [HttpPost("send_message")]
        public ActionResult SendMessage([FromQuery]string message)
        {
            try
            {
                messageProducer.Produce(message, QUEUE_NAME);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}