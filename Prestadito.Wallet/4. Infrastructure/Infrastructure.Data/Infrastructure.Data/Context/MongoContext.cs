using MongoDB.Driver;
using Prestadito.Wallet.Domain.MainModule.Entities;
using Prestadito.Wallet.Infrastructure.Data.Interface;
using Prestadito.Wallet.Infrastructure.Data.Utilities;

namespace Prestadito.Wallet.Infrastructure.Data.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase database;

        public MongoContext(IWalletDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionURI);
            database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<DepositEntity> Deposits
        {
            get
            {
                return database.GetCollection<DepositEntity>(CollectionsName.colDeposits);
            }
        }

    }
}
