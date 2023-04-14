using Prestadito.Wallet.Infrastructure.Proxies.Settings.Models;
using Prestadito.Wallet.Infrastructure.Proxies.Settings.Models.Parameters;

namespace Prestadito.Wallet.Infrastructure.Proxies.Settings.Interfaces
{
    public interface ISettingProxy
    {
        ValueTask<ResponseProxyModel<ParameterModel>?> GetParameterByCode(string parameterCode);
    }
}
