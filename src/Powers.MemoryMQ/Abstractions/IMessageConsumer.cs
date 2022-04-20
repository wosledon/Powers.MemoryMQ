using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Powers.MemoryMQ.Abstractions;

public interface IMessageConsumer<TKey, TValue> : IPubSub, IDisposable
{
    void OnMessage(Action<(TKey, TValue)> callback);
    CancellationTokenSource Cancel();
    void Subscribe();
    void Unsubscribe();
}
