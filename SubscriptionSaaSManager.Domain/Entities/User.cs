using SubscriptionSaaSManager.Domain.Entities._bases;
using SubscriptionSaaSManager.Domain.Validations;

namespace SubscriptionSaaSManager.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

        public User()
        {
        }

        public User(string username, string passwordHash, string email, int tenantId, Guid? uiid = null, DateTime? createAt = null, int? id = null) :base(uiid,createAt,id)
        {
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            TenantId = tenantId;
            
           
            Validate(); 
        }

        public override void Validate()
        {
            RuleValidator.Build()
                .When(string.IsNullOrEmpty(Username), "Username is required.")
                .When(string.IsNullOrEmpty(PasswordHash), "Password is required.")
                .When(!IsValidEmail(Email), "Invalid email format.")
                .ThrowExceptionIfExists();
            base.Validate();
        }

        private bool IsValidEmail(string email) =>
            System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

}


