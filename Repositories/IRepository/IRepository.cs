namespace TestApi.Repositories.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();

    }
}
