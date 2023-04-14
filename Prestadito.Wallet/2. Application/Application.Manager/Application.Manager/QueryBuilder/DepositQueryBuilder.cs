using MongoDB.Driver;
using Prestadito.Wallet.Application.Manager.QueryBuilder.FilterDefinition;
using Prestadito.Wallet.Application.Manager.QueryBuilder.UpdateDefinition;
using Prestadito.Wallet.Domain.MainModule.Entities;

namespace Prestadito.Wallet.Application.Manager.QueryBuilder
{
    public static class DepositQueryBuilder
    {
        public static Tuple<FilterDefinition<DepositEntity>, UpdateDefinition<DepositEntity>> UpdateDepositDisable(string depositId)
        {
            var filterDefinition = DepositFilterDefinition.FindDepositById(depositId);
            var updateDefinition = DepositUpdateDefinition.Disable();

            return Tuple.Create(filterDefinition, updateDefinition);
        }

        public static FilterDefinition<DepositEntity> FindAllDeposits()
        {
            var query = DepositFilterDefinition.FindAllDeposits();
            return query;
        }

        public static FilterDefinition<DepositEntity> FindDepositsActive()
        {
            var query = DepositFilterDefinition.FindDepositsActive();
            return query;
        }

        public static FilterDefinition<DepositEntity> FindDepositById(string depositId)
        {
            var query = DepositFilterDefinition.FindDepositById(depositId);
            return query;
        }

        public static UpdateDefinition<DepositEntity> UpdateDeposit(DepositEntity entity)
        {
            var updateDefinition = DepositUpdateDefinition.UpdateDeposit(entity);
            return updateDefinition;
        }
    }
}
