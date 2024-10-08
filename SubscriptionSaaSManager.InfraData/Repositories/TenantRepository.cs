﻿using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.InfraData.Context;
using SubscriptionSaaSManager.InfraData.Interfaces;
using SubscriptionSaaSManager.InfraData.Repositories._bases;

namespace SubscriptionSaaSManager.InfraData.Repositories
{
    public class TenantRepository(ApplicationDbContext context) : RepositoryBase<Tenant>(context), ITenantyRepository
    {
    }
}
