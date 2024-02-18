using RabbitMqConsumer;
using RabbitMqConsumer.ServiceBus;
using RabbitMqConsumer.Storage;
using RabbitMqConsumer.Wrappers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMessageStore, MessageStore>();
builder.Services.AddTransient<IConfigurationWrapper, ConfigurationWrapper>();
builder.Services.AddSingleton<IMessageConsumer, MessageConsumer>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.SubscribeMessageConsumer();

app.Run();