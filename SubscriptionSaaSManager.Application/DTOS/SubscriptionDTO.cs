namespace SubscriptionSaaSManager.Application.DTOS
{
    public class SubscriptionDTO
    {
        public string? Name { get; set; } 
        public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserId { get; set; }
        public int? Frequency { get; set; }
        public int? Id { get; set; }
        public Guid? UIID { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
