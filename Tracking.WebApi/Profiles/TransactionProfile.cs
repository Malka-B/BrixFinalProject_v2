using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.WebApi.DTO;
using Transaction.Data.Entities;
using Transaction.Service.Models;

namespace Tracking.WebApi.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionModel, TransactionDTO>();
            CreateMap<TransactionDTO, TransactionModel>();
            CreateMap<TransactionEntity, TransactionModel>();
            CreateMap<TransactionModel, TransactionEntity>();
        }
    }
}
