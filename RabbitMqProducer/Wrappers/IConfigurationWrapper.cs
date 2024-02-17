namespace RabbitMqProducer.Wrappers
{
    internal interface IConfigurationWrapper
    {
        string GetSection(string sectionName);
    }
}