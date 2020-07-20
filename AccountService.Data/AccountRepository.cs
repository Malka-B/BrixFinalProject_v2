using Account.Data.Entites;
using Account.Service.Intefaces;
using Account.Service.Models;
using AutoMapper;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Account.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMapper _mapper;
        private readonly AccountContext _accountContext;
        public AccountRepository(IMapper mapper, AccountContext accountContext)
        {
            _accountContext = accountContext;
            _mapper = mapper;
        }

        public async Task<AccountModel> GetAccountInfoAsync(Guid CustomerId)
        {
            try
            {
                AccountEntity accountEntity = await _accountContext.Accounts.Include(c=>c.Customer)
                                .FirstOrDefaultAsync(a => a.CustomerId == CustomerId);
                if (accountEntity != null)
                {
                     AccountModel accountModel = _mapper.Map<AccountModel>(accountEntity);
                    return accountModel;
                }
                else
                    throw new AccountNotFoundException();
            }
            catch(AccountNotFoundException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new SystemException();
            }
        }
    }
}

