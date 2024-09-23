using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task CreateProduct([FromBody] ProductRequest productRequest)
        {
            await productService.CreateProduct(productRequest);
        }

        [HttpPut]
        public async Task UpdateProduct(int id, [FromBody] ProductRequest productRequest)
        {
            await productService.UpdateProduct(id, productRequest);
        }

        [HttpGet("{id}")]
        public async Task<ProductResponse> GetProductById(int id)
        {
            return await productService.GetProductById(id);
        }

        [HttpGet]
        public async Task<List<ProductResponse>> GetAllProducts()
        {
            return await productService.GetAllProducts();
        }

        [HttpPatch("{id}")]
        public async Task DeleteProduct(int id)
        {
            await productService.DeleteProduct(id);
        }

    }
}
