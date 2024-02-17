using RabbitMQ.Client;
using RabbitMqConsumer.ServiceBus;
using RabbitMqProducer.Wrappers;
using System.Text;

namespace RabbitMqProducer.ServiceBus
{
    internal class MessageProducer : IMessageProducer
    {
        private const string RABBIT_CONFIG_SECTION_NAME = "RabbitMq";
        private readonly IConfigurationWrapper configuration;

        public MessageProducer(IConfigurationWrapper configuration) => this.configuration = configuration;

        public void Produce(string message, string queueName)
        {
            var connectionFactory = new ConnectionFactory() { Uri = GetConnectionUri() };
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            QueueDeclare(channel, queueName);
            PublishMessage(channel, message, queueName);
        }

        private Uri GetConnectionUri() => new Uri(configuration.GetSection(RABBIT_CONFIG_SECTION_NAME));

        private void PublishMessage(IModel channel, string message, string queueName)
        {
            byte[] body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(string.Empty, queueName, null, body);
        }

        private void QueueDeclare(IModel channel, string queueName)
            => channel.QueueDeclare(queueName, false, false, false);
    }
}