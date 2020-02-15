using StackExchange.Redis;
using System;
using System.Timers;

namespace Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var multiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            var db = multiplexer.GetDatabase();

            var startTime = DateTime.Now;
            var timer = new Timer { Interval = 1 };
            timer.Elapsed += (_, e) =>
            {
                var milliseconds = (e.SignalTime - startTime).TotalMilliseconds;
                db.StreamAdd("sin", "val", Math.Sin(milliseconds / 1e3), messageId: Math.Floor(milliseconds * 1000) + "-0");
            };
            timer.Start();

            Console.WriteLine("Writing...");
            Console.ReadLine();
        }
    }
}
