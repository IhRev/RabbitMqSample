﻿using RabbitMqProducer.Exceptions;

namespace RabbitMqProducer.Wrappers.Implementations
{
    internal class ConfigurationWrapper(IConfiguration configuration) : IConfigurationWrapper
    {
        public string GetSection(string sectionName) 
            => configuration[sectionName]
            ?? throw new ConfigurationNotFoundException($"Configuration not found {sectionName}");
    }
}