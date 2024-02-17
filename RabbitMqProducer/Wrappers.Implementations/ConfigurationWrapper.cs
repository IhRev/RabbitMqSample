using RabbitMqProducer.Exceptions;

namespace RabbitMqProducer.Wrappers.Implementations
{
    internal class ConfigurationWrapper : IConfigurationWrapper
    {
        private readonly IConfiguration configuration;

        public ConfigurationWrapper(IConfiguration configuration) => this.configuration = configuration;

        public string GetSection(string sectionName) 
            => configuration[sectionName]
            ?? throw new ConfigurationNotFoundException($"Configuration not found {sectionName}");
    }
}