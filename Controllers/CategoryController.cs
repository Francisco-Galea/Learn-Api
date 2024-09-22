using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public async Task CreateCategory([FromBody] CategoryRequest categoryRequest)
        {
            await categoryService.CreateCategory(categoryRequest);
        }

        [HttpPut("{id}")]
        public async Task UpdateCategory(int id, [FromBody] CategoryRequest categoryRequest)
        {
            await categoryService.UpdateCategory(id, categoryRequest);
        }

        [HttpGet("{id}")]
        public async Task<CategoryResponse> GetCategoryById(int id)
        {
            return await categoryService.GetCategoryById(id);
        }

        [HttpGet]
        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            return await categoryService.GetAllCategories();
        }        

        [HttpPatch]
        public async Task DeleteCategory(int id)
        {
            await categoryService.DeleteCategory(id);
        }

    }
}
