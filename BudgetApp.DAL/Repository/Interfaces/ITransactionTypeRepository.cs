using BudgetApp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.DAL.Repository.Interfaces
{
    public interface ITransactionTypeRepository
    {
        Task<IList<TransactionType>> GetTransactionTypes();
    }
}