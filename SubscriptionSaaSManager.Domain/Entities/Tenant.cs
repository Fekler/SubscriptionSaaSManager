using SubscriptionSaaSManager.Domain.Entities._bases;
using SubscriptionSaaSManager.Domain.Validations;

namespace SubscriptionSaaSManager.Domain.Entities
{
    public class Tenant : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Tenant(string name)
        {
            Name = name;

            Validate(); // Chama a validação no construtor
        }

        public override void Validate()
        {
            RuleValidator.Build()
                .When(string.IsNullOrEmpty(Name), "Tenant name is required.")
                .ThrowExceptionIfExists();
        }
    }
}