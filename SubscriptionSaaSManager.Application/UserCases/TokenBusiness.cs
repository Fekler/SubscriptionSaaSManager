using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SubscriptionSaaSManager.Application.UserCases
{
    public class TokenBusiness(string key, IMemoryCache memoryCache) : ITokenService
    {
        private readonly string _key = key;
        private readonly IMemoryCache _cache = memoryCache; 


        public AuthResponse GenerateToken(Guid userId, Permission permission)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);

            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Role, permission.Name)
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            var refreshToken = GenerateRefreshToken(userId);

            return new AuthResponse
            {
                UserId = userId,
                Permission = permission.Name,
                Token = jwtToken,
                RefreshToken = refreshToken.Token,
                ExpiresAt = tokenDescriptor.Expires.Value
            };
        }

        private RefreshToken GenerateRefreshToken(Guid userId)
        {
            var refreshToken = new RefreshToken
            {
                UserId = userId,
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };

            _cache.Set(refreshToken.Token, refreshToken, refreshToken.ExpiryDate);

            return refreshToken;
        }

        public RefreshToken GetStoredRefreshToken(string refreshToken, Guid userId)
        {
            if (_cache.TryGetValue(refreshToken, out RefreshToken storedToken))
            {
                if (storedToken.UserId == userId && storedToken.ExpiryDate > DateTime.UtcNow)
                {
                    return storedToken;
                }
            }

            return null; 
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            _cache.Remove(refreshToken);
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false // Aqui permite validar um token expirado
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Token inválido");
            }

            return principal;
        }
    }
}



