namespace RabbitMqConsumer.ServiceBus
{
    public interface IMessageConsumer
    {
        void Consume(string queueName);
    }
}