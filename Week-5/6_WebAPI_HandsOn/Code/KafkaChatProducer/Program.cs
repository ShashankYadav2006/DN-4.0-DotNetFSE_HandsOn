using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaChatProducer
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            using var producer = new ProducerBuilder<string, string>(config).Build();
            Console.WriteLine("=== Kafka Chat Producer ===");
            Console.WriteLine("Type your messages (type 'exit' to quit):");
            Console.WriteLine("Format: [Username]: [Message]");
            Console.WriteLine();
            string message;
            while ((message = Console.ReadLine()) != "exit")
            {
                if (!string.IsNullOrEmpty(message))
                {
                    try
                    {
                        var chatMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                        
                        var result = await producer.ProduceAsync("chat-messages", 
                            new Message<string, string>
                            {
                                Key = Guid.NewGuid().ToString(),
                                Value = chatMessage
                            });

                        Console.WriteLine($"Message sent to partition {result.Partition} at offset {result.Offset}");
                    }
                    catch (ProduceException<string, string> ex)
                    {
                        Console.WriteLine($"Error sending message: {ex.Error.Reason}");
                    }
                }
            }
            producer.Flush(TimeSpan.FromSeconds(10));
            Console.WriteLine("Producer shutting down...");
        }
    }
}