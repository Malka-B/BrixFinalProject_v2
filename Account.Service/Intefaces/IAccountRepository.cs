using Account.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Intefaces
{
    public interface IAccountRepository
    {
        Task<bool> CreateAccountAsync(CreateAccountModel createAccountModel);
        Task<Guid> LoginAsync(loginModel loginModel);
        Task<AccountModel> GetAccountInfoAsync(Guid CustomerId);
    }
}
