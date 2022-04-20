using System;
using Xunit;
using Powers.MemoryMQ.Abstractions;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Powers.MemoryMQ.Test;

public class MemoryMQTest
{
    private readonly ITestOutputHelper _output;

    public MemoryMQTest(ITestOutputHelper output)
    {
        _output = output;
    }

    public class TestObject
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Address: {Address}";
        }
    }

    [Fact]
    public async Task Test1()
    {
        _output.WriteLine("测试开始");
        MessageChannel<string, object> Channel = new();
        MessageProducer producer = new(Channel);
        MessageConsumer consumer = new(Channel);

        for (var i = 0; i < 20; i++)
        {
            await producer.ProduceAsync($"0x000{i}", i);
        }

        consumer.OnMessage((message) =>
        {
            //_output.WriteLine("1");
            _output.WriteLine($"{message.Item1.ToString()}");
            //_output.WriteLine($"{message.Item1} <> {(message.Item2 as TestObject)?.ToString()}");
        });

        _output.WriteLine("测试结束");
    }
}
