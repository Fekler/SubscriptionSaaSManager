﻿using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.Domain.Interfaces._bases;

namespace SubscriptionSaaSManager.InfraData.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByEmail(string email);
        Task<List<User>> GetAllByTenandId(int tenantId);
    }
}
