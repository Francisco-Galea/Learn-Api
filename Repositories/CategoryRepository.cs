using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task Insert(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();   
        }

        public override async Task Update(Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }

        public override async Task<Category> GetById(int id)
        {
            return await context
                         .Categories
                         .Where(c => c.CategoryId == id && c.IsCategoryActive == true)
                         .FirstAsync();
        }

        public override async Task<List<Category>> GetAll()
        {
            return await context
                         .Categories
                         .Where(c => c.IsCategoryActive == true)
                         .ToListAsync();
        }
    }
}
