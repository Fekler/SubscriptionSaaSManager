using SubscriptionSaaSManager.Domain.Entities._bases;

namespace SubscriptionSaaSManager.Domain.Entities
{
    public class Permission : EntityBase
    {
        public Permission()
        {
        }

        public string Name { get; set; } // Ex: Admin, User
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Permission(string name, int userId, Guid? uiid = null, DateTime? createAt = null, int? id = null) : base(uiid, createAt, id)
        {
            Name = name;
            UserId = userId;
        }

        public override void Validate()
        {

            base.Validate();
        }
    }

}
