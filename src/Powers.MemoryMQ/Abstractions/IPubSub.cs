using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Powers.MemoryMQ.Abstractions;
public interface IPubSub
{
    /// <summary>
    /// 主题
    /// </summary>
    /// <value></value>
    string TopicName { get; }
}
