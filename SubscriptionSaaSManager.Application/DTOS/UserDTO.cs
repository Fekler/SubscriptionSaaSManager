namespace SubscriptionSaaSManager.Application.DTOS
{
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public int? TenantId { get; set; }
        public int? Id { get; set; }
        public Guid? UIID { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
