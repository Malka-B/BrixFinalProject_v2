using Account.Service.Intefaces;
using Account.Service.Models;
using System;
using System.Threading.Tasks;

namespace Account.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<bool> CreateAccountAsync(CreateAccountModel createAccountModel)
        {
            bool isEmailValid = await _loginRepository.IsEmailValidAsync(createAccountModel.Email);
            if (isEmailValid)
            {
                return await _loginRepository.CreateAccountAsync(createAccountModel);
            }

            return false;
        }

        public async Task<Guid> LoginAsync(string email, string password)
        {
            return await _loginRepository.LoginAsync(email, password);
        }
    }
}
