using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Domain.Entities;

namespace SubscriptionSaaSManager.Application.Interfaces
{
    public interface ITokenService
    {
        AuthResponse GenerateToken(Guid userId, Permission permission);
        RefreshToken GetStoredRefreshToken(string refreshToken, Guid userId);
    }
}
