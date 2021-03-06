using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BudgetApp.DAL.DBHandler
{
    public interface ISqlDataMapper
    {
        IDbConnection Connection { get; }

        Task ExecuteStoredProc<T>(string sql, T parameters);
        Task<IList<T>> LoadData<T, U>(string sql, U paramters);
        Task<T> LoadRecord<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}