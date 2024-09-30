using Microsoft.EntityFrameworkCore;
using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.InfraData.Context;
using SubscriptionSaaSManager.InfraData.Interfaces;
using SubscriptionSaaSManager.InfraData.Repositories._bases;

namespace SubscriptionSaaSManager.InfraData.Repositories
{
    public class UserRepository(ApplicationDbContext context) : RepositoryBase<User>(context), IUserRepository
    {
        public async Task<User> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<List<User>> GetAllByTenandId(int tenantId)
        {
            return await _dbSet.Where(u => u.TenantId == tenantId).ToListAsync();
        }
    }
}
