using MongoDB.Driver;
using Prestadito.Wallet.Domain.MainModule.Entities;

namespace Prestadito.Wallet.Infrastructure.Data.Interface
{
    public interface IMongoContext
    {
        IMongoCollection<DepositEntity> Deposits { get; }
    }
}
