using Microsoft.EntityFrameworkCore;
using SubscriptionSaaSManager.Domain.Entities;


namespace SubscriptionSaaSManager.InfraData.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Tenant)
                .WithMany()
                .HasForeignKey(u => u.TenantId);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Permission>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

        }
    }
    
}
