using MongoDB.Driver;
using Prestadito.Wallet.Domain.MainModule.Entities;

namespace Prestadito.Wallet.Application.Manager.QueryBuilder.FilterDefinition
{
    public static class DepositFilterDefinition
    {
        public static FilterDefinition<DepositEntity> FindDepositById(string depositId)
        {
            var filter = Builders<DepositEntity>.Filter.Eq(s => s.Id, depositId);
            return filter;
        }

        public static FilterDefinition<DepositEntity> FindAllDeposits()
        {
            var filter = Builders<DepositEntity>.Filter.Empty;
            return filter;
        }

        public static FilterDefinition<DepositEntity> FindDepositsActive()
        {
            var filter = Builders<DepositEntity>.Filter.Eq(s => s.BlnActive, true);
            return filter;
        }
    }
}
