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
        IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<bool> CreateAccountAsync(CreateAccountModel createAccountModel)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountModel> GetAccountInfoAsync(Guid CustomerId)
        {
            return await _accountRepository.GetAccountInfoAsync(CustomerId);
        }

        public Task<Guid> LoginAsync(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
