namespace a2Algo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<bool> CreateAsync(T entity);  
        bool UpdateAsync(T entity);  
        bool DeleteAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
