using Account.Service.Intefaces;
using Account.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data
{
    public class AccountRepository : IAccountRepository
    {
        

        public Task<AccountModel> GetAccountInfoAsync(Guid CustomerId)
        {
            throw new NotImplementedException();
        }

        
    }
}
