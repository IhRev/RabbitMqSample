namespace RabbitMqConsumer.ServiceBus
{
    public interface IMessageProducer
    {
        void Produce(string message, string queueName);
    }
}