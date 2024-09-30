using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Application.Interfaces._bases;
using SubscriptionSaaSManager.Domain.Entities;

namespace SubscriptionSaaSManager.Application.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        Task<ApiResponse<User>> ValidateUserCredentials(string email, string password);
    }
}
