using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powers.MemoryMQ.Abstractions;

namespace sample.Powers.MemoryMQ.Sample.Services;

public class MemoryMQService : BackgroundService
{
    private readonly IMessageConsumer<string, object> _consumer;

    public MemoryMQService(IMessageConsumer<string, object> consumer)
    {
        _consumer = consumer;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.OnMessage(async (message) =>
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Key: {message.Item1.ToString()}, Value: {message.Item2.ToString()}");
            });
        });

        return Task.CompletedTask;
    }
}
