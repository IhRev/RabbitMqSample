using RabbitMqConsumer.ServiceBus;

namespace RabbitMqConsumer
{
    internal static class StartupExtensions
    {
        private const string QUEUE_NAME = "TestQueue";

        public static void SubscribeMessageConsumer(this IApplicationBuilder app)
        {
            IMessageConsumer consumer = app.ApplicationServices.GetRequiredService<IMessageConsumer>();
            consumer.Consume(QUEUE_NAME);
        }
    }
}