using Azure.Messaging.ServiceBus;

public class LogService
{
    private readonly string _connectionString;
    private readonly string _queueName;

    public LogService(string connectionString, string queueName)
    {
        _connectionString = connectionString;
        _queueName = queueName;
    }

    public async Task LogMessageAsync(string message)
    {
        // Create a Service Bus client
        await using var client = new ServiceBusClient(_connectionString);

        // Create a sender for the queue
        await using ServiceBusSender sender = client.CreateSender(_queueName);

        // Create a message
        var serviceBusMessage = new ServiceBusMessage(message);

        // Send the message
        await sender.SendMessageAsync(serviceBusMessage);
    }
}