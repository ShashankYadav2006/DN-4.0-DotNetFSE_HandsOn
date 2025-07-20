using System;
using System.Threading;
using Confluent.Kafka;

namespace KafkaChatConsumer
{
    class Program
    {
        private static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "chat-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true
            };
            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe("chat-messages");
            Console.WriteLine("=== Kafka Chat Consumer ===");
            Console.WriteLine("Listening for chat messages... (Press Ctrl+C to exit)");
            Console.WriteLine();
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };
            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cts.Token);
                        
                        if (consumeResult != null)
                        {
                            Console.WriteLine($"📨 {consumeResult.Message.Value}");
                            Console.WriteLine($"   [Partition: {consumeResult.Partition}, Offset: {consumeResult.Offset}]");
                            Console.WriteLine();
                        }
                    }
                    catch (ConsumeException ex)
                    {
                        Console.WriteLine($"Error consuming message: {ex.Error.Reason}");
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                consumer.Close();
                Console.WriteLine("Consumer shutting down...");
            }
        }
    }
}