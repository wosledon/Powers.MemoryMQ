using System.Security.Cryptography;
using System;
using Powers.MemoryMQ;
using Powers.MemoryMQ.Abstractions;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var MAX_COUNT = 100;

MessageChannel<string, object> Channel = new();
MessageProducer producer = new(Channel);
MessageConsumer consumer = new(Channel);

Task.Run(async () =>
{
    for (var i = 0; i < MAX_COUNT; i++)
    {
        await producer.ProduceAsync($"0x000{i}", new TestObject
        {
            Name = $"张三-{i}",
            Age = i,
            Address = $"{i}-{i}-{i}-{i}-{i}-{i}-{i}"
        });
        await Task.Delay(20);
    }

});

await Task.Run(() =>
{
    var count = 0;
    while (true)
    {
        consumer.OnMessage((message) =>
        {
            count++;
            //_output.WriteLine("1");
            Console.WriteLine($"{message.Item1} <> {(message.Item2 as TestObject)?.ToString()}");
            //_output.WriteLine($"{message.Item1} <> {(message.Item2 as TestObject)?.ToString()}");
        });

        if (count >= MAX_COUNT)
        {
            break;
        }
        //Task.Delay(200);
    }
});

Console.WriteLine("Hello, World!");


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
