using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOrderedController : ControllerBase
    {
        private readonly ItemOrderedService itemOrderedService;

        public ItemOrderedController(ItemOrderedService itemOrderedService)
        {
            this.itemOrderedService = itemOrderedService;
        }

        [HttpPost]
        public async Task CreateItemOrdered([FromBody] ItemOrderedRequest itemOrderedRequest)
        {
            await itemOrderedService.CreateItemOrdered(itemOrderedRequest);
        }

        [HttpPut]
        public async Task UpdateItemOrdered(int id, [FromBody] ItemOrderedRequest itemOrderedRequest)
        {
            await itemOrderedService.UpdateItemOrdered(id, itemOrderedRequest);
        }

        [HttpGet("{id}")]
        public async Task<ItemOrderedResponse> GetItemOrderedById(int id)
        {
            return await itemOrderedService.GetItemOrderedById(id);
        }

        [HttpGet]
        public async Task<List<ItemOrderedResponse>> GetAllItemsOrdered()
        {
            return await itemOrderedService.GetAllItemsOrdered();
        }

        [HttpPatch("{id}")]
        public async Task DeleteItemOrdered(int id)
        {
            await itemOrderedService.DeleteItemOrdered(id);
        }

    }
}
