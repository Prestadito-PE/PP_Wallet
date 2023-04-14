using Microsoft.Extensions.DependencyInjection;
using Prestadito.Wallet.Infrastructure.Proxies.Settings.Interfaces;
using Prestadito.Wallet.Infrastructure.Proxies.Settings.Proxies;

namespace Prestadito.Wallet.Infrastructure.Proxies.Settings.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProxies(this IServiceCollection services)
        {
            services.AddHttpClient<ISettingProxy, SettingProxy>();

            return services;
        }
    }
}
