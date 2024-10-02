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
using System.Runtime.InteropServices;

namespace SubscriptionSaaSManager.IOC
{
    public class Ioc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Env.Load();

            string envConnectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            if (string.IsNullOrEmpty(envConnectionString))
            {
                envConnectionString = configuration.GetConnectionString("DefaultConnection");
            }
            string envJWT = Environment.GetEnvironmentVariable("TOKEN_JWT_SECRET");
            if (string.IsNullOrEmpty(envConnectionString))
            {
                envConnectionString = configuration["TOKEN_JWT_SECRET"];
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(envConnectionString));


            services.AddMemoryCache();

            services.AddSingleton<ITokenService>(provider =>
            {
                var memoryCache = provider.GetRequiredService<IMemoryCache>();
                return new TokenBusiness(envJWT, memoryCache);
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

