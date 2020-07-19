using Account.Service.Models;
using Account.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Account.Data.Entites;

namespace Account.WebApi.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, AccountDTO>();
            CreateMap<AccountDTO, AccountModel>();
            CreateMap<AccountEntity, AccountModel>()
                .ForPath(dest => dest.FirstName, option => option.MapFrom
                   (src => src.Customer.FirstName))
                .ForPath(dest => dest.LastName, option => option.MapFrom
                   (src => src.Customer.LastName));
            CreateMap<AccountModel, AccountEntity>()
               .ForPath(dest => dest.Customer.FirstName, option => option.MapFrom
                   (src => src.FirstName))
                 .ForPath(dest => dest.Customer.LastName, option => option.MapFrom
                   (src => src.LastName));
            CreateMap<AccountEntity, AccountModel>();
        }
    }
}
