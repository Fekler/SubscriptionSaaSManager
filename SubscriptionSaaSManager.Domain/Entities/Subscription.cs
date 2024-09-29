using SubscriptionSaaSManager.Domain.Entities._bases;
using SubscriptionSaaSManager.Domain.Validations;
using static SubscriptionSaaSManager.Domain.Utils.Enums;

namespace SubscriptionSaaSManager.Domain.Entities
{
    public class Subscription : EntityBase
    {
        public string Name { get; set; } // Ex: Netflix, Prime
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public BillingFrequency Frequency { get; set; } // Nova propriedade para frequência de pagamento

        public virtual User User { get; set; }
        public Subscription(string name, decimal price, DateTime startDate, DateTime endDate, int userId, BillingFrequency frequency)
        {
            Name = name;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            UserId = userId;
            Frequency = frequency;

            Validate(); 
        }

        public override void Validate()
        {
            RuleValidator.Build()
                .When(string.IsNullOrEmpty(Name), "Name is required.")
                .When(Price <= 0, "Price must be greater than zero.")
                .When(StartDate >= EndDate, "Start date must be before end date.")
                .ThrowExceptionIfExists();
        }
    }
}