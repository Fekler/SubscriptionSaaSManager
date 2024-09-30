using SubscriptionSaaSManager.Domain.Entities._bases;
using SubscriptionSaaSManager.Domain.Validations;

namespace SubscriptionSaaSManager.Domain.Entities
{
    public class Tenant : EntityBase
    {
        public string Name { get; set; }


        public Tenant()
        {
        }
        public Tenant(string name, Guid? uiid = null, DateTime? createAt = null, int? id = null) : base(uiid, createAt, id)
        {
            Name = name;

            Validate(); // Chama a validação no construtor
        }



        public override void Validate()
        {
            RuleValidator.Build()
                .When(string.IsNullOrEmpty(Name), "Tenant name is required.")
                .ThrowExceptionIfExists();
            base.Validate();
        }
    }
}