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
    }
}
