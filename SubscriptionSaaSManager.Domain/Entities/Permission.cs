using SubscriptionSaaSManager.Domain.Entities._bases;

namespace SubscriptionSaaSManager.Domain.Entities
{
    public class Permission:EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } // Ex: Admin, User
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }

}
