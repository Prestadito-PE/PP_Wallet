using MongoDB.Driver;
using Prestadito.Wallet.Domain.MainModule.Entities;

namespace Prestadito.Wallet.Infrastructure.Data.Interface
{
    public interface IDepositRepository
    {
        ValueTask<DepositEntity> GetSingleAsync(FilterDefinition<DepositEntity> filterDefinition);
        ValueTask<IEnumerable<DepositEntity>> GetAsync(FilterDefinition<DepositEntity> filterDefinition);
        ValueTask InsertOneAsync(DepositEntity entity);
        ValueTask<bool> UpdateOneAsync(FilterDefinition<DepositEntity> filterDefinition, UpdateDefinition<DepositEntity> updateDefinition);
        ValueTask<bool> DeleteOneAsync(FilterDefinition<DepositEntity> filterDefinition);
    }
}
