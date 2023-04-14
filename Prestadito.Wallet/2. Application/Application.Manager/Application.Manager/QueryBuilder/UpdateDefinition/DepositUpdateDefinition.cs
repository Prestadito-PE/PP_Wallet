using MongoDB.Driver;
using Prestadito.Wallet.Domain.MainModule.Entities;

namespace Prestadito.Wallet.Application.Manager.QueryBuilder.UpdateDefinition
{
    public static class DepositUpdateDefinition
    {
        public static UpdateDefinition<DepositEntity> Disable()
        {
            var update = Builders<DepositEntity>.Update.Set(u => u.BlnActive, false);
            return update;
        }

        public static UpdateDefinition<DepositEntity> UpdateDeposit(DepositEntity entity)
        {
            var update = Builders<DepositEntity>.Update
                .Set(u => u.BlnActive, entity.BlnActive)
                .Set(u => u.DteUpdatedAt, entity.DteUpdatedAt)
                .Set(u => u.StrUpdateUser, entity.StrUpdateUser);
            return update;
        }
    }
}
