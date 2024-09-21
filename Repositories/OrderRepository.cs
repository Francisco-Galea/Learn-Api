using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task Insert(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        //Revisar metodo
        public override async Task Update(Order order)
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }

        public override async Task<Order?> GetById(int id)
        {
            return await context
                         .Orders
                         .Include(o => o.OUser)
                         .Where(o => o.IsOrderActive == true && o.OrderId == id)
                         .FirstAsync();
        }

        public override async Task<List<Order>> GetAll()
        {
            return await context
                         .Orders
                         .Include(o => o.OUser)
                         .Where(o => o.IsOrderActive == true)
                         .ToListAsync();
        }

    }
}
