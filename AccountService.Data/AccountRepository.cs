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
        public Task<bool> CreateAccountAsync(CreateAccountModel createAccountModel)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountModel> GetAccountInfoAsync(Guid CustomerId)
        {
            AccountEntity accountEntity = await _accountContext.Accounts
                .FirstOrDefaultAsync(a => a.CustomerId == CustomerId);
            if (accountEntity != null)
            {
                ///
                ///
                ///
                ///check fi we need it
                //AccountModel accountModel = new AccountModel()
                //{
                //    Balance = accountEntity.Balance,
                //    OpenDate = accountEntity.OpenDate,
                //    FirstName = accountEntity.Customer.FirstName,
                //    LastName = accountEntity.Customer.LastName
                //};
                AccountModel accountModel = _mapper.Map<AccountModel>(accountEntity);
                return accountModel;
            }
            else
                return null;
        }

        public Task<Guid> LoginAsync(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
