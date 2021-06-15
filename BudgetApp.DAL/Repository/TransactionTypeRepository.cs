using BudgetApp.DAL.DBHandler;
using BudgetApp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.DAL.Repository.Interfaces;

namespace BudgetApp.DAL.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly ISqlDataMapper _db;

        public TransactionTypeRepository(ISqlDataMapper db)
        {
            _db = db;
        }

        public async Task<IList<TransactionType>> GetTransactionTypes()
        {
            var sQuery = "SELECT * FROM TransactionType";

            return await _db.LoadData<TransactionType, dynamic>(sQuery, new { });
        }
    }
}
