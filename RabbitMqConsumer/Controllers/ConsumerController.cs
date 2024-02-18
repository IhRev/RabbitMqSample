using Microsoft.AspNetCore.Mvc;
using RabbitMqConsumer.Storage;

namespace RabbitMqConsumer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsumerController(IMessageStore messageStore) : ControllerBase
    {
        [HttpGet("messages")]
        public ActionResult<IEnumerable<string>> GetAllMessages()
        {
            try
            {
                return Ok(messageStore.GetMessages());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}