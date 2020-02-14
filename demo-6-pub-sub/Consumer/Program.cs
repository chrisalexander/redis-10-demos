using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Consumer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var multiplexer = await ConnectionMultiplexer.ConnectAsync("127.0.0.1:6379");
            var pubsub = multiplexer.GetSubscriber();

            Console.WriteLine("Consumer");
            Console.Write("# ");

            var tcs = new TaskCompletionSource<bool>();

            pubsub.Subscribe("chars").OnMessage(m =>
            {
                Console.Write(m.Message);

                if (m.Message.Equals("x"))
                {
                    tcs.SetResult(true);
                }
            });

            await tcs.Task;
        }
    }
}
