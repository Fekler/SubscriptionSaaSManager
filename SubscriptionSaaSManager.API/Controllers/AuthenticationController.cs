using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Domain.Entities;
using System.Security.Claims;

namespace SubscriptionSaaSManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(ITokenService tokenService, IUserService userService, ILogger<AuthenticationController> logger) : Controller
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUserService _userService = userService;
        private readonly ILogger<AuthenticationController> _logger = logger;

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            // Valida as credenciais do usuário
            var user = await _userService.ValidateUserCredentials(loginRequest.Email, loginRequest.Password);
            if (!user.Success)
                return Unauthorized("Invalid credentials");

            // Recupera as permissões do usuário (Admin/User)
            //var userPermission = _userService.GetUserPermission(user.Id);

            // Gera os tokens (JWT e RefreshToken)
            //var authResponse = _tokenService.GenerateToken(user.Data.UIID, "Admin");
            var authResponse = _tokenService.GenerateToken(user.Data.UIID, new Permission("Admin", user.Data.Id));

            return Ok(authResponse); // Retorna o AuthResponseDto contendo Token, RefreshToken e outros dados
        }
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] RefreshTokenRequest refreshRequest)
        {
            try
            {
                var principal = _tokenService.GetPrincipalFromExpiredToken(refreshRequest.Token);
                var userId = new Guid(principal.FindFirst(ClaimTypes.NameIdentifier).Value);

                // Busca o RefreshToken na memória
                var storedRefreshToken = _tokenService.GetStoredRefreshToken(refreshRequest.RefreshToken, userId);

                if (storedRefreshToken == null)
                    return Unauthorized(); // RefreshToken inválido ou expirado

                // Se o token for válido, gere um novo e remova o anterior
                _tokenService.RevokeRefreshToken(refreshRequest.RefreshToken);

                var permission = principal.FindFirst(ClaimTypes.Role).Value;
                var newAuthResponse = _tokenService.GenerateToken(userId, new Permission { Name = permission });

                return Ok(newAuthResponse);
            }
            catch (SecurityTokenException)
            {
                return Unauthorized();
            }
        }

    }
}
