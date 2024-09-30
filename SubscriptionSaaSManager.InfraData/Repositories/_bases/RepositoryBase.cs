using SubscriptionSaaSManager.Domain.Entities._bases;
using SubscriptionSaaSManager.Domain.Interfaces._bases;
using SubscriptionSaaSManager.InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace SubscriptionSaaSManager.InfraData.Repositories._bases
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;


        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<int> Add(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid guid)
        {
            var entity = await _dbSet.FindAsync(guid);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(int id) => await _dbSet.FindAsync(id);
        public async Task<T> Get(Guid uiid) => await _dbSet.FindAsync(uiid);

        public async Task<bool> Update(T entity)
        {
            var existingEntity = await _dbSet.FindAsync(entity.Id);
            if (existingEntity == null)
                return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
