using Account.Data.Entites;
using Account.Service.Intefaces;
using Account.Service.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMapper _mapper;
        private readonly AccountContext _accountContext;
        public AccountRepository(IMapper mapper,AccountContext accountContext)
        {
            _accountContext = accountContext;
            _mapper = mapper;
        }
        public async Task<AccountModel> GetAccountInfoAsync(Guid CustomerId)
        {
            try
            {
                AccountEntity accountEntity = await _accountContext.Accounts
                    .Include(a => a.Customer)
                    .FirstOrDefaultAsync(a => a.CustomerId.ToString()==(CustomerId.ToString().ToUpper()));
                AccountModel accountModel = _mapper.Map<AccountModel>(accountEntity);
                return accountModel;

            }
            
         catch(Exception ex)
            {
                return null;
            }
                ///check fi we need it
                //AccountModel accountModel = new AccountModel()
                //{
                //    Balance = accountEntity.Balance,
                //    OpenDate = accountEntity.OpenDate,
                //    FirstName = accountEntity.Customer.FirstName,
                //    LastName = accountEntity.Customer.LastName
                //};

            

        }


    }
}
