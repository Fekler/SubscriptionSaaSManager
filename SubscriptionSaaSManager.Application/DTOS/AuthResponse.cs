using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSaaSManager.Application.DTOS
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string Permission { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
