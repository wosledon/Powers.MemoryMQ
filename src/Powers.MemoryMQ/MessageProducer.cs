using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powers.MemoryMQ.Abstractions;

namespace Powers.MemoryMQ;

public class MessageProducer : IMessageProducer<string, object>
{
    public string TopicName => "MemoryMQ";

    private MessageChannel<string, object> Channel;

    public MessageProducer(MessageChannel<string, object> channel)
    {
        Channel = channel;
    }

    public void Dispose()
    {
    }

    public async ValueTask ProduceAsync(string key, object value, CancellationToken cancellationToken = default)
    {
        await Channel.Channel.Writer.WriteAsync((key, value), cancellationToken);
    }
}
