using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.InfraData.Context;
using SubscriptionSaaSManager.InfraData.Interfaces;
using SubscriptionSaaSManager.InfraData.Repositories._bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSaaSManager.InfraData.Repositories
{
    public class TenantRepository(ApplicationDbContext context) : RepositoryBase<Tenant>(context), ITenantyRepository
    {
    }
}
