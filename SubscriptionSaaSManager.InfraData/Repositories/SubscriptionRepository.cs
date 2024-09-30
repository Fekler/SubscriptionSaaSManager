using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.InfraData.Context;
using SubscriptionSaaSManager.InfraData.Interfaces;
using SubscriptionSaaSManager.InfraData.Repositories._bases;

namespace SubscriptionSaaSManager.InfraData.Repositories
{
    public class SubscriptionRepository(ApplicationDbContext context) : RepositoryBase<Subscription>(context), ISubscriptionRepository
    {
    }
}
