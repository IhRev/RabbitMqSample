using RabbitMqConsumer.Exceptions;

namespace RabbitMqConsumer.Wrappers
{
    internal class ConfigurationWrapper(IConfiguration configuration) : IConfigurationWrapper
    {
        public string GetSection(string sectionName)
            => configuration[sectionName]
            ?? throw new ConfigurationNotFoundException($"Configuration not found {sectionName}");
    }
}