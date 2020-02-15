using System.Threading.Tasks;
using Consumer.Model;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Consumer.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ConnectionMultiplexer multiplexer;

        public DataController() : base() => this.multiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");

        [HttpGet]
        public async Task<Data> GetAsync(string since = "0-0")
        {
            var result = await this.multiplexer
                                    .GetDatabase()
                                    .StreamReadAsync("sin", since);

            var data = new double[result.Length][];

            for (var i = 0; i < result.Length; i++)
            {
                var point = new double[2];
                point[0] = double.Parse(result[i].Id.ToString()[0..^3]) / 1000;
                point[1] = double.Parse(result[i].Values[0].Value);
                data[i] = point;
            }

            var lastId = result.Length > 0 ? result[^1].Id.ToString() : since;

            return new Data { Points = data, LastId = lastId };
        }
    }
}
