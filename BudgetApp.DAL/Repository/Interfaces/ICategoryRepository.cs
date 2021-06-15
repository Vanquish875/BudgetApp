using BudgetApp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.DAL.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IList<CategoryType>> GetCategories();
    }
}