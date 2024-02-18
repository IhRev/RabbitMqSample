namespace RabbitMqConsumer.Wrappers
{
    internal interface IConfigurationWrapper
    {
        string GetSection(string sectionName);
    }
}