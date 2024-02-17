using RabbitMqConsumer.ServiceBus;
using RabbitMqProducer.ServiceBus;
using RabbitMqProducer.Wrappers;
using RabbitMqProducer.Wrappers.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConfigurationWrapper, ConfigurationWrapper>();
builder.Services.AddScoped<IMessageProducer, MessageProducer>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();