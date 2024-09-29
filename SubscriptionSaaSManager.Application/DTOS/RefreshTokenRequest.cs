namespace SubscriptionSaaSManager.Application.DTOS
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
