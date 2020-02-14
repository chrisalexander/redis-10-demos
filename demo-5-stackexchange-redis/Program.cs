using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace StackExchangeRedisDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var multiplexer = await ConnectionMultiplexer.ConnectAsync("localhost:6379");

            var str = await multiplexer.GetDatabase().StringGetAsync("stackexchange");

            Console.WriteLine($"stackexchange = {str}");

            // To's the string
            var val = Guid.NewGuid().ToString();

            await multiplexer.GetDatabase().StringSetAsync("stackexchange2", val);

            Console.WriteLine($"stackexchange2 = {val}");
        }
    }
}
