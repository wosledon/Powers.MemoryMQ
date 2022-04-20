using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Powers.MemoryMQ.Abstractions
{
    public interface IMemoryMQBuilder
    {
        IServiceCollection Services { get; }
    }

    public interface IMemoryMQCustomBuilder
    {
        IMemoryMQBuilder MemoryMQBuilder { get; }
        IMemoryMQBuilder Builder();
    }
}
