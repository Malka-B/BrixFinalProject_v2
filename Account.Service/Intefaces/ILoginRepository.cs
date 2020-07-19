using Account.Service.Models;
using System;
using System.Threading.Tasks;

namespace Account.Service.Intefaces
{
    public interface ILoginRepository
    {
        Task<bool> CreateAccountAsync(CreateAccountModel createAccountModel);
        Task<Guid> LoginAsync(string email, string password);
        Task<bool> IsEmailValidAsync(string email);
    }
}
