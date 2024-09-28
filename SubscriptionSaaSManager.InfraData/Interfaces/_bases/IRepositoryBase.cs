using SubscriptionSaaSManager.Domain.Entities._bases;

namespace SubscriptionSaaSManager.Domain.Interfaces._bases
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        public Task<int> Add(T entity);
        public Task<bool> Delete(int id);
        public Task<T> Get(int id, CancellationToken cancellationToken);
        public Task<T> Get(Guid guid, CancellationToken cancellationToken);
        public Task<bool> Update(T entity);
    }
}
