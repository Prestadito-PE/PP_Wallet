using Prestadito.Wallet.Infrastructure.Data.Interface;

namespace Prestadito.Wallet.Infrastructure.Data.Settings
{
    public class WalletDBSettings : IWalletDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
