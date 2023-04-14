using FluentValidation;
using Prestadito.Wallet.Application.Dto.Deposit.CreateDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.DisableDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.GetDepositById;
using Prestadito.Wallet.Application.Dto.Deposit.UpdateDeposit;
using Prestadito.Wallet.Infrastructure.Data.Constants;

namespace Prestadito.Wallet.Application.Manager.Validators
{
    public class GetDepositByIdValidator : AbstractValidator<GetDepositByIdRequest>
    {
        public GetDepositByIdValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class CreateDepositValidator : AbstractValidator<CreateDepositRequest>
    {
        public CreateDepositValidator()
        {
            RuleFor(x => x.DblDepositAmount)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblFinancialTransactionTax)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrUserId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrDepositNumber)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrVerificationNumber)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DteDeposit)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrBankCode)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class UpdateDepositValidator : AbstractValidator<UpdateDepositRequest>
    {
        public UpdateDepositValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblDepositAmount)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblFinancialTransactionTax)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrUserId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrDepositNumber)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrVerificationNumber)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DteDeposit)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrBankCode)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class DisableDepositValidator : AbstractValidator<DisableDepositRequest>
    {
        public DisableDepositValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class DeleteDepositValidator : AbstractValidator<DeleteDepositRequest>
    {
        public DeleteDepositValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }
}
