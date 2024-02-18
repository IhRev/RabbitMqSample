namespace RabbitMqConsumer.Storage
{
    public interface IMessageStore
    {
        void AddMessage(string msg);

        IEnumerable<string> GetMessages();
    }
}