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

        public Task<AccountModel> GetAccountInfoAsync(Guid CustomerId)
        {
            throw new NotImplementedException();
        }

        
    }
}
