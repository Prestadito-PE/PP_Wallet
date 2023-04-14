using AutoMapper;
using Prestadito.Wallet.Application.Dto.Deposit.CreateDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.DisableDeposit;
using Prestadito.Wallet.Application.Dto.Deposit.GetDepositById;
using Prestadito.Wallet.Application.Dto.Deposit.GetDepositsActive;
using Prestadito.Wallet.Application.Dto.Deposit.UpdateDeposit;
using Prestadito.Wallet.Domain.MainModule.Entities;
using Prestadito.Wallet.Infrastructure.Data.Constants;
using Prestadito.Wallet.Infrastructure.Data.Utilities;

namespace Prestadito.Wallet.Application.Manager.Profiles
{
    public class DepositProfile : Profile
    {
        public DepositProfile()
        {
            CreateMap<CreateDepositRequest, DepositEntity>()
                .ForMember(dest => dest.BlnActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.StrCreateUser, opt => opt.MapFrom(src => ConstantAPI.System.SYSTEM_USER));

            CreateMap<DepositEntity, CreateDepositResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<DepositEntity, GetDepositByIdResponse>();

            CreateMap<UpdateDepositRequest, DepositEntity>();

            CreateMap<DepositEntity, UpdateDepositResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<DepositEntity, DisableDepositResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<DepositEntity, DeleteDepositResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<DepositEntity, GetDepositsActiveResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
