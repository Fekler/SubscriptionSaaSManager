using SubscriptionSaaSManager.Domain.Entities._bases;

namespace SubscriptionSaaSManager.Domain.Interfaces._bases
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<int> Add(T entity);
        Task<bool> Delete(int id);
        Task<bool> Delete(Guid uiid);
        Task<T> Get(int id);
        Task<T> Get(Guid guid);
        Task<bool> Update(T entity);
    }
}
