namespace SubscriptionSaaSManager.Application.DTOS
{
    public class PermissionDTO
    {
        public string? Name { get; set; } // Ex: Admin, User
        public int? UserId { get; set; }
        public int? Id { get; set; }
        public Guid? UIID { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
