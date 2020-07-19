using Account.Data.Entites;
using Account.Service.Intefaces;
using Account.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Account.Data
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AccountContext _accountContext;
        public LoginRepository(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public async Task<bool> IsEmailValidAsync(string email)
        {
            CustomerEntity customerEntity = await _accountContext.Customers
                                                .FirstOrDefaultAsync(s => s.Email == email);
            if (customerEntity != null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CreateAccountAsync(CreateAccountModel createAccountModel)
        {
            
        }

        public async Task<Guid> LoginAsync(string email, string password)
        {
            try
            {
                var customer = await _accountContext.Customers.FirstOrDefaultAsync(c =>
            c.Email == email &&
            c.Passowrd == password);

                if (customer != null)
                {
                    return customer.Id;
                }
                else
                {
                    return default;
                }
            }
            catch(Exception e)
            {
                throw new Exception();
            }      
            
        }
    }
}
