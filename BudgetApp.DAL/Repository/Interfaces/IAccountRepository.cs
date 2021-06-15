using BudgetApp.DAL.Models;
using BudgetApp.DAL.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.DAL.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task CreateAccount(Account account);
        Task DeleteAccount(int AccountID);
        Task<GetAccount> GetAccountByID(int AccountID);
        Task<IList<Account>> GetAccounts();
        Task<IList<AccountTypeNameCombine>> GetAccountTypeNames();
        Task UpdateAccount(Account account);
    }
}