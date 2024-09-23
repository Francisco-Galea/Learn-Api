using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly OrderService orderService;

        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task CreateOrder([FromBody] OrderRequest orderRequest)
        {
            await orderService.CreateOrder(orderRequest);
        }

        [HttpPut("{id}")]
        public async Task UpdateOrder(int id, [FromBody] OrderRequest orderRequest)
        {
            await orderService.UpdateOrder(id, orderRequest);
        }

        [HttpGet("{id}")]
        public async Task<OrderResponse> GetOrderById(int id)
        {
            return await orderService.GetOrderById(id);
        }

        [HttpGet]
        public async Task<List<OrderResponse>> GetAllUsers()
        {
            return await orderService.GetAllOrders();
        }

        [HttpPatch("{id}")]
        public async Task DeactivateOrder(int id)
        {
            await orderService.DeactivateOrder(id);
        }

    }
}
