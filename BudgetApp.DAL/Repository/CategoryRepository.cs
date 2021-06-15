using BudgetApp.DAL.DBHandler;
using BudgetApp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.DAL.Repository.Interfaces;

namespace BudgetApp.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISqlDataMapper _db;

        public CategoryRepository(ISqlDataMapper db)
        {
            _db = db;
        }

        public async Task<IList<CategoryType>> GetCategories()
        {
            var sQuery = "SELECT * FROM Categories";

            return await _db.LoadData<CategoryType, dynamic>(sQuery, new { });
        }
    }
}
