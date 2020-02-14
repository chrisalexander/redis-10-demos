using StackExchange.Redis;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoadShakespeare
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var multiplexer = await ConnectionMultiplexer.ConnectAsync("127.0.0.1:6379");

            var f = File.OpenText(@"shakespeare.txt");

            var lineNumber = 0;
            string line;
            while ((line = f.ReadLine()) != null)
            {
                lineNumber++;

                // Skip headers and footers
                if (lineNumber < 245 || lineNumber > 124438)
                {
                    continue;
                }

                var words = line.Split(' ').Where(w => w.Length > 0).ToList();

                // Ignore short sentences
                if (words.Count <= 3)
                {
                    continue;
                }

                foreach (var word in words)
                {
                    var insertWord = Regex.Replace(word, @"\p{P}", "").ToLower();

                    multiplexer.GetDatabase().HyperLogLogAdd("shakespeare", insertWord);
                }

                if (lineNumber % 10000 == 0)
                {
                    Console.WriteLine($"Line {lineNumber} done");
                }
            }
        }
    }
}
