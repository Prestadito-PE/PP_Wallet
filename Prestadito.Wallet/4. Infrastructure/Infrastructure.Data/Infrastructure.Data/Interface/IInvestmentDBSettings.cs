namespace Prestadito.Wallet.Infrastructure.Data.Interface
{
    public interface IWalletDBSettings
    {
        string ConnectionURI { get; set; }
        string DatabaseName { get; set; }
    }
}
