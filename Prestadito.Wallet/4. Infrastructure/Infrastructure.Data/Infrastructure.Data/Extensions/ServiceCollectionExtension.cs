using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Prestadito.Wallet.Infrastructure.Data.Context;
using Prestadito.Wallet.Infrastructure.Data.Interface;
using Prestadito.Wallet.Infrastructure.Data.Repositories;
using Prestadito.Wallet.Infrastructure.Data.Settings;

namespace Prestadito.Wallet.Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        private static IServiceCollection AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WalletDBSettings>(configuration.GetSection(nameof(WalletDBSettings)));
            services.AddSingleton<IWalletDBSettings>(sp => sp.GetRequiredService<IOptions<WalletDBSettings>>().Value);
            services.AddScoped<IMongoContext, MongoContext>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDepositRepository, DepositRepository>();

            return services;
        }

        public static IServiceCollection AddDBServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDbContext(configuration);
            services.AddRepositories();

            return services;
        }
    }
}
