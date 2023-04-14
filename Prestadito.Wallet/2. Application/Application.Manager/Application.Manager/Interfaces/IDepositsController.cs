using Microsoft.AspNetCore.Http;
using Prestadito.Wallet.Application.Dto.Deposit.CreateDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.GetDepositById;
using Prestadito.Wallet.Application.Dto.Deposit.UpdateDeposit;

namespace Prestadito.Wallet.Application.Manager.Interfaces
{
    public interface IDepositsController
    {
        ValueTask<IResult> CreateDeposit(CreateDepositRequest request, string path);
        ValueTask<IResult> GetAllDeposits();
        ValueTask<IResult> GetActiveDeposits();
        ValueTask<IResult> GetDepositById(GetDepositByIdRequest request);
        ValueTask<IResult> UpdateDeposit(UpdateDepositRequest request);
        ValueTask<IResult> DisableDeposit(string id);
        ValueTask<IResult> DeleteDeposit(DeleteDepositRequest request);
    }
}
