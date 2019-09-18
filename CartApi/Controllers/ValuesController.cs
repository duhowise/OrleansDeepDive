using System.Threading.Tasks;
using GrainInterfaces;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IClusterClient _client;

        public ValuesController(IClusterClient client)
        {
            _client = client;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var grain = _client.GetGrain<IValueGrain>(id);
            return await grain.GetValue();
        }

        // POST api/values
        [HttpPost]
        public void Post(int id,[FromBody] string value)
        {
            var grain =_client.GetGrain<IValueGrain>(id);
            grain.SetValue(value);
        }

    }
}
