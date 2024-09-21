using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task Insert(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        //Revisar metodo
        public override async Task Update(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }        

        public override async Task<User> GetById(int id)
        {
            return await context
                         .Users
                         .Where(u => u.IsUserActive == true && u.UserId == id)                        
                         .FirstAsync();
        }

        public override async Task<List<User>> GetAll()
        {
            return await context
                         .Users
                         .Where(u => u.IsUserActive == true)
                         .ToListAsync();
        }

    }
}
