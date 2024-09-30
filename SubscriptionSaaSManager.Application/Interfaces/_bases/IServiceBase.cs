using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Domain.Entities._bases;

namespace SubscriptionSaaSManager.Application.Interfaces._bases
{
    public interface IServiceBase<T> where T : EntityBase
    {
        Task<ApiResponse<int>> Add(object dto);
        Task<ApiResponse<bool>> Delete(int id);
        Task<ApiResponse<bool>> Delete(Guid guid);
        Task<ApiResponse<T>> Get(int id);
        Task<ApiResponse<T>> Get(Guid guid);
        Task<ApiResponse<bool>> Update(object dto);
    }
}
