namespace SubscriptionSaaSManager.Application.DTOS
{
    public record TenantDTO
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
        public Guid? UIID { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
