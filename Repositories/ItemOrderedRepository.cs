using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Repositories
{
    public class ItemOrderedRepository : Repository<ItemOrdered>, IItemOrderedRepository
    {
        private readonly ApplicationDbContext context;
        public ItemOrderedRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        
        public override async Task Insert(ItemOrdered itemOrdered)
        {
            await context.ItemsOrdered.AddAsync(itemOrdered);
            await context.SaveChangesAsync();
        }

        public override async Task Update(ItemOrdered itemOrdered)
        {
            context.ItemsOrdered.Update(itemOrdered);
            await context.SaveChangesAsync();
        }

        public override async Task<ItemOrdered> GetById(int id)
        {
            return await context
                         .ItemsOrdered
                         .Where(i => i.ItemOrderedId == id && i.IsItemOrderedActive == true)
                         .Include(i => i.OProduct)
                         .ThenInclude(p => p.OCategory)
                         .FirstAsync();
        }

        public override async Task<List<ItemOrdered>> GetAll()
        {
            return await context
                         .ItemsOrdered
                         .Where(i => i.IsItemOrderedActive == true)
                         .Include(i => i.OProduct)
                         .ThenInclude(p => p.OCategory)
                         .ToListAsync();
        }
        

    }
}
