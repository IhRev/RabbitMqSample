using RabbitMQ.Client;
using RabbitMqConsumer.ServiceBus;
using RabbitMqProducer.Wrappers;
using System.Text;

namespace RabbitMqProducer.ServiceBus
{
    internal class MessageProducer(IConfigurationWrapper configuration) : IMessageProducer
    {
        private const string RABBIT_CONFIG_SECTION_NAME = "MessageBroker";

        public void Produce(string message, string queueName)
        {
            var connectionFactory = new ConnectionFactory() { Uri = GetConnectionUri() };
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            QueueDeclare(channel, queueName);
            PublishMessage(channel, message, queueName);
        }

        private Uri GetConnectionUri() => new(configuration.GetSection(RABBIT_CONFIG_SECTION_NAME));

        private static void PublishMessage(IModel channel, string message, string queueName)
        {
            byte[] body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(string.Empty, queueName, null, body);
        }

        private static void QueueDeclare(IModel channel, string queueName)
            => channel.QueueDeclare(queueName, false, false, false);
    }
}