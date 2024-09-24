using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task Insert(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }


        public override async Task Update(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }

        public override async Task<Product> GetById(int id)
        {
            return await context
                         .Products
                         .Where(p => p.IsProductActive == true && p.ProductId == id)
                         .Include(p => p.OCategory)
                         .FirstAsync();
        }

        public override async Task<List<Product>> GetAll()
        {
            return await context
                         .Products
                         .Where(p => p.IsProductActive == true)
                         .Include(p => p.OCategory)
                         .ToListAsync();
        }

    }
}
