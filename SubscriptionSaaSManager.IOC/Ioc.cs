using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Application.UserCases;
using SubscriptionSaaSManager.InfraData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



            services.AddSingleton<ITokenService>(provider =>
            {
                var memoryCache = provider.GetRequiredService<IMemoryCache>();
                return new TokenBusiness(jwtSecret, memoryCache);
            });
        }
    }
}

