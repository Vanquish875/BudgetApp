using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.DAL.DBHandler
{
    public class SqlDataMapper : ISqlDataMapper
    {
        private readonly IConfiguration _config;

        public SqlDataMapper(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<IList<T>> LoadData<T, U>(string sql, U paramters)
        {
            using IDbConnection conn = Connection;
            var data = await conn.QueryAsync<T>(sql, paramters);
            return data.ToList();
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            using IDbConnection conn = Connection;
            await conn.ExecuteAsync(sql, parameters);
        }

        public async Task<T> LoadRecord<T, U>(string sql, U parameters)
        {
            using IDbConnection conn = Connection;
            var data = await conn.QueryAsync<T>(sql, parameters);
            return data.FirstOrDefault();
        }

        public async Task ExecuteStoredProc<T>(string sql, T parameters)
        {
            using IDbConnection conn = Connection;
            await conn.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
