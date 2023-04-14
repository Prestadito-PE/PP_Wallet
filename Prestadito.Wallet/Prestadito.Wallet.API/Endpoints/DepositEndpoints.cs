using FluentValidation;
using Prestadito.Wallet.Application.Dto.Deposit.CreateDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.DisableDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.GetDepositById;
using Prestadito.Wallet.Application.Dto.Deposit.UpdateDeposit;
using Prestadito.Wallet.Application.Manager.Interfaces;
using Prestadito.Wallet.Infrastructure.Data.Constants;

namespace Prestadito.Wallet.API.Endpoints
{
    public static class DepositEndpoints
    {
        readonly static string collection = "deposits";
        public static WebApplication UseDepositEndpoints(this WebApplication app, string basePath)
        {
            string path = $"{basePath}/{collection}";

            app.MapPost(path,
                async (IValidator<CreateDepositRequest> validator, CreateDepositRequest dto, IDepositsController controller) =>
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.CreateDeposit(dto, $"~{path}");
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path + "/all",
                async (IDepositsController controller, HttpContext httpContext) =>
                {
                    return await controller.GetAllDeposits();
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path,
                async (IDepositsController controller) =>
                {
                    return await controller.GetActiveDeposits();
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path + "/{id}",
                async (IValidator<GetDepositByIdRequest> validator, string id, IDepositsController controller) =>
                {
                    var request = new GetDepositByIdRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.GetDepositById(request);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapPut(path,
                async (IValidator<UpdateDepositRequest> validator, UpdateDepositRequest dto, IDepositsController controller) =>
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.UpdateDeposit(dto);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapPut(path + "/disable/{id}",
                async (IValidator<DisableDepositRequest> validator, string id, IDepositsController controller) =>
                {
                    var request = new DisableDepositRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.DisableDeposit(id);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapDelete(path + "/delete/{id}",
                async (IValidator<DeleteDepositRequest> validator, string id, IDepositsController controller) =>
                {
                    var request = new DeleteDepositRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.DeleteDeposit(request);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            return app;
        }
    }
}
