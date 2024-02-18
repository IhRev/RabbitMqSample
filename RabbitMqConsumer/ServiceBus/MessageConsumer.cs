using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqConsumer.Storage;
using RabbitMqConsumer.Wrappers;
using System.Text;

namespace RabbitMqConsumer.ServiceBus
{
    internal class MessageConsumer(IConfigurationWrapper configuration, IMessageStore messageStore) : IMessageConsumer
    {
        private const string RABBIT_CONFIG_SECTION_NAME = "MessageBroker";
        private readonly Lazy<string> uri = new(() => configuration.GetSection(RABBIT_CONFIG_SECTION_NAME));

        public void Consume(string queueName)
        {
            var connectionFactory = new ConnectionFactory() { Uri = new Uri(uri.Value) };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            QueueDeclare(channel, queueName);
            StartConsuming(channel, queueName);
        }

        private void StartConsuming(IModel channel, string queueName)
        {
            EventingBasicConsumer consumer = CreateConsumer(channel);
            channel.BasicConsume(queueName, true, consumer);
        }

        private EventingBasicConsumer CreateConsumer(IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += EventReceived;
            return consumer;
        }

        private void EventReceived(object? sender, BasicDeliverEventArgs args)
        {
            byte[] body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            messageStore.AddMessage(message);
            Console.WriteLine(message);
        }

        private static void QueueDeclare(IModel channel, string queueName) 
            => channel.QueueDeclare(queueName, false, false, false);
    }
}