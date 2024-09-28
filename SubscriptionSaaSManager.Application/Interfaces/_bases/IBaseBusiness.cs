using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Domain.Entities._bases;

namespace SubscriptionSaaSManager.Application.Interfaces._bases
{
    public interface IBaseBusiness<T> where T : EntityBase
    {

        Task<ApiResponse<T>> Get(int id);
        Task<ApiResponse<int>> Add(object entity);
        Task<ApiResponse<bool>> Delete(int id);
        Task<ApiResponse<bool>> Update(object entity);

    }
}
