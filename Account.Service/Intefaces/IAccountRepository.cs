using Account.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Intefaces
{
    public interface IAccountRepository
    {
        
        Task<AccountModel> GetAccountInfoAsync(Guid CustomerId);
    }
}
