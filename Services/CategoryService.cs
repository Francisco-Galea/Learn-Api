using AutoMapper;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Models.Entities;
using TestApi.Repositories;
using TestApi.Repositories.IRepository;

namespace TestApi.Services
{
    public class CategoryService
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task CreateCategory(CategoryRequest categoryRequest)
        {
            var category = mapper.Map<Category>(categoryRequest);
            category.IsCategoryActive = true;
            await categoryRepository.Insert(category);
        }

        public async Task UpdateCategory(int id, CategoryRequest categoryRequest)
        {
            var existCategory = await categoryRepository.GetById(id);
            if(existCategory == null)
            {
                throw new Exception("No se ha encontrado la categoria");
            }
            else
            {
                mapper.Map(categoryRequest, existCategory);
                await categoryRepository.Update(existCategory);
            }
        }
       
        public async Task<CategoryResponse> GetCategoryById(int id)
        {
            var category = await categoryRepository.GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException("No se ha encontrado la categoria");
            }
            else
            {
                return mapper.Map<CategoryResponse>(category);
            }
        }

        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            var categories = await categoryRepository.GetAll();
            return mapper.Map<List<CategoryResponse>>(categories);
        }

        public async Task DeleteCategory(int id)
        {
            var category = await categoryRepository.GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException("No se ha encontrado la categoria");
            }
            else
            {
                category.IsCategoryActive = false;
                await categoryRepository.Update(category);
            }
        }

    }
}
