using BudgetApp.DAL.Models;
using BudgetApp.DAL.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.DAL.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        Task CreateTransaction(Transaction transaction);
        Task DeleteTransaction(int transactionId);
        Task<Transaction> GetTransactionByID(int transactionId);
        Task<IList<TransactionAccount>> GetTransactions();
        Task<IList<Transaction>> GetTransactionsByAccount(int accountID);
        Task UpdateTransaction(Transaction transaction);
    }
}