using SubscriptionSaaSManager.Domain.Validations;

namespace SubscriptionSaaSManager.Domain.Entities._bases
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public Guid UIID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        protected EntityBase()
        {
            
        }

        protected EntityBase(Guid? uiid = null, DateTime? createAt = null, int? id = null)
        {
            if (!id.HasValue)
            {
                CreateAt = DateTime.UtcNow;
                UIID = Guid.NewGuid();
            }
            else
            {
                Id = id.Value;
                UpdateAt = DateTime.UtcNow;
                CreateAt = createAt.Value;
            }
        }
        public virtual void Validate()
        {
            RuleValidator.Build()
                .When(Id < 0, Error.ID)
                .When(UIID == Guid.Empty, "UIID cannot be an empty GUID.")
                .When(Id > 0 && CreateAt == default , "CreateAt must be a valid date.")
                
                .ThrowExceptionIfExists();
        }
    }
}
