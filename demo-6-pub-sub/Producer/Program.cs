using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Producer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var multiplexer = await ConnectionMultiplexer.ConnectAsync("127.0.0.1:6379");
            var pubsub = multiplexer.GetSubscriber();

            Console.WriteLine("Producer");
            Console.Write("> ");

            var character = '0';

            while (character != 'x')
            {
                await pubsub.PublishAsync("chars", character.ToString());

                character = Console.ReadKey().KeyChar;
            }

            await pubsub.PublishAsync("chars", character.ToString());
        }
    }
}
