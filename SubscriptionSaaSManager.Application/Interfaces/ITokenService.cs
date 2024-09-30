using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Domain.Entities;
using System.Security.Claims;

namespace SubscriptionSaaSManager.Application.Interfaces
{
    public interface ITokenService
    {
        AuthResponse GenerateToken(Guid userId, Permission permission);
        RefreshToken GetStoredRefreshToken(string refreshToken, Guid userId);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        void RevokeRefreshToken(string refreshToken);
    }
}
