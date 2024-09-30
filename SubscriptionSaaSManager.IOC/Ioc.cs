using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Application.UserCases;
using SubscriptionSaaSManager.InfraData.Context;
using SubscriptionSaaSManager.InfraData.Interfaces;
using SubscriptionSaaSManager.InfraData.Repositories;

namespace SubscriptionSaaSManager.IOC
{
    public class Ioc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            Env.Load();

            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            var jwtSecret = Environment.GetEnvironmentVariable("TOKEN_JWT_SECRET");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));


            services.AddMemoryCache();

            services.AddSingleton<ITokenService>(provider =>
            {
                var memoryCache = provider.GetRequiredService<IMemoryCache>();
                return new TokenBusiness(jwtSecret, memoryCache);
            });

            services.AddScoped<IUserService, UserBusiness>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITenantService, TenantBusiness>();
            services.AddScoped<ITenantyRepository, TenantRepository>();

            services.AddScoped<ISubscriptionService, SubscriptionBusiness>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            services.AddScoped<IPermissionService, PermissionBusiness>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
        }
    }
}

