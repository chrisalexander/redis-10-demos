using GeoServer.Model;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoServer.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ConnectionMultiplexer multiplexer;

        public CityController() : base() => this.multiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");

        [HttpGet]
        public async Task<IEnumerable<City>> GetAsync(double lat, double lng, double r = 100)
        {
            var result = await this.multiplexer
                                    .GetDatabase()
                                    .GeoRadiusAsync("cities", lng, lat, r, GeoUnit.Miles, order: Order.Ascending, options: GeoRadiusOptions.WithCoordinates);

            return result.Select(r => new City { Name = r.Member, Lat = r.Position.Value.Latitude, Lng = r.Position.Value.Longitude });
        }
    }
}
