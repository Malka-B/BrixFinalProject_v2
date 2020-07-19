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

       

        public async Task<Guid> LoginAsync(string email, string password)
        {
            string passwordAsHashCode = password.GetHashCode().ToString();
            return await _loginRepository.LoginAsync(email, passwordAsHashCode);
        }

        public async Task<bool> RegisterAsync(CustomerModel customerModel)
        {
            bool isEmailValid = await _loginRepository.IsEmailValidAsync(customerModel.Email);
            if (isEmailValid)
            {
                customerModel.Id = Guid.NewGuid();
                customerModel.Password = (customerModel.Password.GetHashCode()).ToString();

                AccountRegisterModel account = new AccountRegisterModel
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerModel.Id,
                    Balance = 1000,
                    OpenDate = DateTime.Now
                };
                return await _loginRepository.RegisterAsync(customerModel, account);
            }

            return false;
        }
    }
}
