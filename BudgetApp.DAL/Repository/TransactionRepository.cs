using BudgetApp.DAL.DBHandler;
using BudgetApp.DAL.Models;
using BudgetApp.DAL.Queries;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.DAL.Repository.Interfaces;

namespace BudgetApp.DAL.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ISqlDataMapper _db;

        public TransactionRepository(ISqlDataMapper db) => _db = db;

        public async Task<IList<TransactionAccount>> GetTransactions()
        {
            var sQuery = @"SELECT AccountName, Amount, c.Category, tp.TransactionTypeName, Recurring, RecurringDate, tr.TransactionDate
                          FROM [BudgetApp].[dbo].[Transactions] tr
                          JOIN [BudgetApp].[dbo].[Accounts] ac
                          on tr.AccountID = ac.AccountID
                          JOIN [BudgetApp].[dbo].[TransactionType] tp
                          on tr.TransactionTypeID = tp.TransactionTypeID
                          JOIN [BudgetApp].[dbo].[Categories] c
                          on tr.CategoryID = c.CategoryID";

            return await _db.LoadData<TransactionAccount, dynamic>(sQuery, new { });
        }
        public async Task<Transaction> GetTransactionByID(int transactionId)
        {
            var sQuery = "SELECT * FROM Transactions WHERE TransactionID = @ID";

            return await _db.LoadRecord<Transaction, dynamic>(sQuery, new { ID = transactionId });
        }
        public async Task<IList<Transaction>> GetTransactionsByAccount(int accountID)
        {
            var sQuery = @"SELECT AccountName, Amount, c.Category, tp.TransactionType, Recurring, RecurringDate
                          FROM [BudgetApp].[dbo].[Transactions] tr
                          JOIN [BudgetApp].[dbo].[Accounts] ac
                          on tr.AccountID = ac.AccountID
                          JOIN [BudgetApp].[dbo].[TransactionType] tp
                          on tr.TransactionTypeID = tp.TransactionTypeID
                          JOIN [BudgetApp].[dbo].[Categories] c
                          on tr.CategoryID = c.CategoryID
                          WHERE tr.AccountID = @ID";

            return await _db.LoadData<Transaction, dynamic>(sQuery, new { ID = accountID });
        }
        public Task CreateTransaction(Transaction transaction)
        {
            if (transaction.TransactionTypeID == 101)
            {
                transaction.Amount *= -1;
            }

            if (!transaction.Recurring)
            {
                transaction.RecurringDate = null;
            }

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@AccountID", transaction.AccountID);
            queryParameters.Add("@Amount", transaction.Amount);
            queryParameters.Add("@TransactionDate", transaction.TransactionDate);
            queryParameters.Add("@CategoryID", transaction.CategoryID);
            queryParameters.Add("@TransactionTypeID", transaction.TransactionTypeID);
            queryParameters.Add("@Recurring", transaction.Recurring);
            queryParameters.Add("@RecurringDate", transaction.RecurringDate);

            var sQuery = @"INSERT INTO [dbo].[Transactions]
                               ([AccountID]
                               ,[Amount]
                               ,[TransactionDate]
                               ,[CategoryID]
                               ,[TransactionTypeID]
                               ,[Recurring]
                               ,[RecurringDate])
                         VALUES
                               (@AccountID
                               ,@Amount
                               ,@TransactionDate
                               ,@CategoryID
                               ,@TransactionTypeID
                               ,@Recurring
                               ,@RecurringDate)";

            return _db.SaveData(sQuery, queryParameters);
        }
        public Task DeleteTransaction(int transactionId)
        {
            var sQuery = "Delete Transaction WHERE TransactionID = @ID";

            return _db.SaveData(sQuery, new { ID = transactionId });
        }
        public Task UpdateTransaction(Transaction transaction)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@TransactionID", transaction.TransactionID);
            queryParameters.Add("@AccountID", transaction.AccountID);
            queryParameters.Add("@Amount", transaction.Amount);
            queryParameters.Add("@TransactionDate", transaction.TransactionDate);
            queryParameters.Add("@CategoryID", transaction.CategoryID);
            queryParameters.Add("@TransactionTypeID", transaction.TransactionTypeID);
            queryParameters.Add("@Recurring", transaction.Recurring);
            queryParameters.Add("@RecurringDate", transaction.RecurringDate);

            var sQuery = @"UPDATE [dbo].[Transactions]
                           SET[AccountID] = @AccountID
                              ,[Amount] = @Amount
                              ,[TransactionDate] = @TransactionDate
                              ,[CategoryID] = @CategoryID
                              ,[TransactionTypeID] = @TransactionTypeID
                              ,[Recurring] = @Recurring
                              ,[RecurringDate] = @RecurringDate
                            WHERE TransactionID = @TransactionID ";

            return _db.SaveData(sQuery, queryParameters);
        }
    }
}
