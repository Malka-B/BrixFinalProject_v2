using Account.Service.Intefaces;
using Account.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service
{
    public class AccountService : IAccountService
    {
        public Task<bool> CreateAccountAsync(CreateAccountModel createAccountModel)
        {
            throw new NotImplementedException();
        }

        public Task<AccountModel> GetAccountInfoAsync(Guid CustomerId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> LoginAsync(loginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
