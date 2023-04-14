using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Prestadito.Wallet.Application.Dto.Deposit.CreateDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.DisableDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.GetDepositById;
using Prestadito.Wallet.Application.Dto.Deposit.GetDepositsActive;
using Prestadito.Wallet.Application.Dto.Deposit.UpdateDeposit;
using Prestadito.Wallet.Application.Manager.Interfaces;
using Prestadito.Wallet.Application.Manager.QueryBuilder;
using Prestadito.Wallet.Application.Manager.Utilities;
using Prestadito.Wallet.Domain.MainModule.Entities;
using Prestadito.Wallet.Infrastructure.Data.Constants;
using Prestadito.Wallet.Infrastructure.Data.Interface;

namespace Prestadito.Wallet.Application.Manager.Controller
{
    public class DepositsController : IDepositsController
    {
        private readonly IDepositRepository _depositRepository;
        private readonly IMapper _mapper;

        public DepositsController(IDepositRepository depositRepository, IMapper mapper)
        {
            _depositRepository = depositRepository;
            _mapper = mapper;
        }

        public async ValueTask<IResult> CreateDeposit(CreateDepositRequest request, string path)
        {
            ResponseModel<CreateDepositResponse> responseModel;

            var entity = _mapper.Map<DepositEntity>(request);

            await _depositRepository.InsertOneAsync(entity);
            if (string.IsNullOrEmpty(entity.Id))
            {
                responseModel = ResponseModel<CreateDepositResponse>.GetResponse(ConstantMessages.Deposits.USER_FAILED_TO_CREATE);
                return Results.UnprocessableEntity(responseModel);
            }

            responseModel = ResponseModel<CreateDepositResponse>.GetResponse(_mapper.Map<CreateDepositResponse>(entity));
            return Results.Created($"{path}/{responseModel.Item.StrId}", responseModel);
        }

        public async ValueTask<IResult> DisableDeposit(string id)
        {
            ResponseModel<DisableDepositResponse> responseModel;

            var (filterDefinition, updateDefinition) = DepositQueryBuilder.UpdateDepositDisable(id);
            var entity = await _depositRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<DisableDepositResponse>.GetResponse(ConstantMessages.Deposits.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }
            entity.BlnActive = false;

            var isDepositUpdated = await _depositRepository.UpdateOneAsync(filterDefinition, updateDefinition);
            if (!isDepositUpdated)
            {
                responseModel = ResponseModel<DisableDepositResponse>.GetResponse(ConstantMessages.Deposits.USER_FAILED_TO_DISABLE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<DisableDepositResponse>(entity);
            responseModel = ResponseModel<DisableDepositResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetActiveDeposits()
        {
            ResponseModel<GetDepositsActiveResponse> responseModel;

            var filterDefinition = DepositQueryBuilder.FindDepositsActive();
            var entities = await _depositRepository.GetAsync(filterDefinition);

            var mapperResponse = _mapper.Map<List<GetDepositsActiveResponse>>(entities.ToList());
            responseModel = ResponseModel<GetDepositsActiveResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetAllDeposits()
        {
            ResponseModel<DepositEntity> responseModel;

            var filterDefinition = DepositQueryBuilder.FindAllDeposits();
            var entities = await _depositRepository.GetAsync(filterDefinition);

            responseModel = ResponseModel<DepositEntity>.GetResponse(entities.ToList());
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetDepositById(GetDepositByIdRequest request)
        {
            ResponseModel<GetDepositByIdResponse> responseModel;

            var filterDefinition = DepositQueryBuilder.FindDepositById(request.StrId);
            var entity = await _depositRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<GetDepositByIdResponse>.GetResponse(ConstantMessages.Deposits.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            var mapperResponse = _mapper.Map<GetDepositByIdResponse>(entity);
            responseModel = ResponseModel<GetDepositByIdResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }
        public async ValueTask<IResult> UpdateDeposit(UpdateDepositRequest dto)
        {
            ResponseModel<UpdateDepositResponse> responseModel;

            var filterDefinition = DepositQueryBuilder.FindDepositById(dto.StrId);
            var entity = await _depositRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<UpdateDepositResponse>.GetResponse(ConstantMessages.Deposits.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            entity.BlnActive = dto.BlnActive;
            entity.DteUpdatedAt = DateTime.Now;
            entity.StrUpdateUser = ConstantAPI.System.SYSTEM_USER;

            var updateDefinition = DepositQueryBuilder.UpdateDeposit(entity);
            var isDepositUpdated = await _depositRepository.UpdateOneAsync(filterDefinition, updateDefinition);
            if (!isDepositUpdated)
            {
                responseModel = ResponseModel<UpdateDepositResponse>.GetResponse(ConstantMessages.Deposits.USER_FAILED_TO_DELETE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<UpdateDepositResponse>(entity);
            responseModel = ResponseModel<UpdateDepositResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> DeleteDeposit(DeleteDepositRequest request)
        {
            ResponseModel<DeleteDepositResponse> responseModel;

            var filterDefinition = DepositQueryBuilder.FindDepositById(request.StrId);
            var entity = await _depositRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<DeleteDepositResponse>.GetResponse(ConstantMessages.Deposits.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            var isDepositUpdated = await _depositRepository.DeleteOneAsync(filterDefinition);
            if (!isDepositUpdated)
            {
                responseModel = ResponseModel<DeleteDepositResponse>.GetResponse(ConstantMessages.Deposits.USER_FAILED_TO_DELETE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<DeleteDepositResponse>(entity);
            responseModel = ResponseModel<DeleteDepositResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }
    }
}
