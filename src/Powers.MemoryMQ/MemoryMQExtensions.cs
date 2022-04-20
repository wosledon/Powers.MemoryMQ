using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Powers.MemoryMQ.Abstractions;

namespace Powers.MemoryMQ;

public static class MemoryMQExtensions
{
    public static IServiceCollection AddMemoryMQProducer(this IServiceCollection service)
    {
        service.TryAddSingleton<MessageChannel<string, Object>>();
        service.TryAddSingleton<IMessageProducer<string, Object>, MessageProducer>();
        return service;
    }

    public static IServiceCollection AddMemoryMQConsumer(this IServiceCollection service)
    {
        service.TryAddSingleton<MessageChannel<string, Object>>();
        service.TryAddSingleton<IMessageConsumer<string, Object>, MessageConsumer>();
        return service;
    }
}
