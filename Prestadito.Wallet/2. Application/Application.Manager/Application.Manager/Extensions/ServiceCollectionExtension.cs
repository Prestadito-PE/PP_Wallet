using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Prestadito.Wallet.Application.Dto.Deposit.CreateDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.DisableDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.GetDepositById;
using Prestadito.Wallet.Application.Dto.Deposit.UpdateDeposit;
using Prestadito.Wallet.Application.Manager.Controller;
using Prestadito.Wallet.Application.Manager.Interfaces;
using Prestadito.Wallet.Application.Manager.Validators;

namespace Prestadito.Wallet.Application.Manager.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetDepositByIdRequest>, GetDepositByIdValidator>();
            services.AddScoped<IValidator<CreateDepositRequest>, CreateDepositValidator>();
            services.AddScoped<IValidator<UpdateDepositRequest>, UpdateDepositValidator>();
            services.AddScoped<IValidator<DisableDepositRequest>, DisableDepositValidator>();
            services.AddScoped<IValidator<DeleteDepositRequest>, DeleteDepositValidator>();

            return services;
        }

        public static IServiceCollection AddWalletControllers(this IServiceCollection services)
        {
            services.AddScoped<IDepositsController, DepositsController>();
            return services;
        }
    }
}
