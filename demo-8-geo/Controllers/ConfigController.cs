using GeoServer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GeoServer.Controllers
{
    [Route("api/config")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly MapsConfig config;

        public ConfigController(IOptions<MapsConfig> config) => this.config = config.Value;

        [HttpGet]
        public MapsConfig Get() => this.config;
    }
}
