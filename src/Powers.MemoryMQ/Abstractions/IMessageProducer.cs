using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Powers.MemoryMQ.Abstractions;

public interface IMessageProducer<TKey, TValue> : IPubSub, IDisposable
{
    ValueTask ProduceAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
}
