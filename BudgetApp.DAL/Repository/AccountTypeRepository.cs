using BudgetApp.DAL.DBHandler;
using BudgetApp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.DAL.Repository.Interfaces;

namespace BudgetApp.DAL.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly ISqlDataMapper _db;

        public AccountTypeRepository(ISqlDataMapper db)
        {
            _db = db;
        }

        public async Task<IList<AccountType>> GetAccountTypes()
        {
            var sQuery = "SELECT * FROM AccountType";

            return await _db.LoadData<AccountType, dynamic>(sQuery, new { });
        }
    }
}
