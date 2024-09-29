namespace SubscriptionSaaSManager.Domain.Entities._bases
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public Guid UIID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }


        public abstract void Validate();
    }
}
