using MongoDB.Driver;
using Prestadito.Wallet.Domain.MainModule.Entities;
using Prestadito.Wallet.Infrastructure.Data.Interface;

namespace Prestadito.Wallet.Infrastructure.Data.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly IMongoContext _context;

        public DepositRepository(IMongoContext context)
        {
            _context = context;
        }

        public async ValueTask<DepositEntity> GetSingleAsync(FilterDefinition<DepositEntity> filterDefinition)
        {
            var result = await _context.Deposits.FindAsync(filterDefinition);
            return await result.SingleOrDefaultAsync();
        }

        public async ValueTask<IEnumerable<DepositEntity>> GetAsync(FilterDefinition<DepositEntity> filterDefinition)
        {
            var result = await _context.Deposits.FindAsync(filterDefinition);
            return result.ToEnumerable();
        }

        public async ValueTask InsertOneAsync(DepositEntity entity)
        {
            await _context.Deposits.InsertOneAsync(entity);
        }

        public async ValueTask<bool> UpdateOneAsync(FilterDefinition<DepositEntity> filterDefinition, UpdateDefinition<DepositEntity> updateDefinition)
        {
            var result = await _context.Deposits.UpdateOneAsync(filterDefinition, updateDefinition);
            return result.IsAcknowledged && result.ModifiedCount == 1;
        }

        public async ValueTask<bool> DeleteOneAsync(FilterDefinition<DepositEntity> filterDefinition)
        {
            var result = await _context.Deposits.DeleteOneAsync(filterDefinition);
            return result.IsAcknowledged && result.DeletedCount == 1;
        }
    }
}
