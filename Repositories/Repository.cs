using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Repositories.IRepository;

namespace TestApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task Insert(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

    }
}
