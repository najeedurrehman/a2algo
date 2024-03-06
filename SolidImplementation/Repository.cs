using a2Algo.Context;
using a2Algo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace a2Algo.SolidImplementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InventoryContext inventory;
        protected readonly DbSet<T> DataContext;

        public Repository(InventoryContext inventoryContext)
        {
            inventory = inventoryContext;
            DataContext = inventory.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await DataContext.AddAsync(entity);
            return true;
        }

        public bool DeleteAsync(T entity)
        {
            DataContext.Remove(entity);
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DataContext.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await DataContext.FindAsync(id);
        }

        public bool UpdateAsync(T entity)
        {
            DataContext.Update(entity);
            return true;
        }


    }
}
