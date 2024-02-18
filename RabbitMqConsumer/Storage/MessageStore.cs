
namespace RabbitMqConsumer.Storage
{
    public class MessageStore : IMessageStore
    {
        private readonly List<string> messages = [];

        public void AddMessage(string msg) => messages.Add(msg);

        public IEnumerable<string> GetMessages() => messages;
    }
}