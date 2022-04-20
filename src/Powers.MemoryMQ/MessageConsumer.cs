using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Powers.MemoryMQ.Abstractions;

namespace Powers.MemoryMQ;

public class MessageConsumer : IMessageConsumer<string, object>
{
    private MessageChannel<string, object> Channel;

    public MessageConsumer(MessageChannel<string, object> channel)
    {
        Channel = channel;
    }

    public CancellationTokenSource Cts { get; } = new CancellationTokenSource();

    public string TopicName { get; } = "MemoryMQ";

    public CancellationTokenSource Cancel()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {

    }

    public void OnMessage(Action<(string, object)> callback)
    {
        Task.Run(async () =>
        {
            while (!Cts.IsCancellationRequested)
            {
                var reader = await Channel.Channel.Reader.ReadAsync(Cts.Token);
                callback(reader);
            }
        });
    }

    public void Subscribe()
    {
        throw new NotImplementedException();
    }

    public void Unsubscribe()
    {
        throw new NotImplementedException();
    }
}

