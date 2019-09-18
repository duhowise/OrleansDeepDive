

using System;
using System.Threading.Tasks;
using GrainInterfaces;
using GrainInterfaces.States;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace CartApi.Controllers
{
   [Route("api/cart")] public class CartController : ControllerBase
    {
        private readonly IClusterClient _client;

        public CartController(IClusterClient client)
        {
            _client = client;
        }

        [HttpGet("{id}")]
        public async Task<Cart> Get(Guid id)
        {
            var grain = _client.GetGrain<ICartGrain>(id);
            return await grain.GetCart();

        }

        [HttpPost("{id}/product")]
        public async Task AddProduct(Guid id,[FromBody] Product product)
        {
            var grain = _client.GetGrain<ICartGrain>(id);
            await grain.AddProducts(product);
        }
    }
}