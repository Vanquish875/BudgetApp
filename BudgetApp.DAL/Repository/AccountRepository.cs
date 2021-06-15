using BudgetApp.DAL.DBHandler;
using BudgetApp.DAL.Models;
using BudgetApp.DAL.Queries;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.DAL.Repository.Interfaces;

namespace BudgetApp.DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ISqlDataMapper _db;

        public AccountRepository(ISqlDataMapper db) => _db = db;

        public Task<IList<Account>> GetAccounts()
        {
            var sQuery = "SELECT * FROM Accounts";

            return _db.LoadData<Account, dynamic>(sQuery, new { });
        }
        public Task<GetAccount> GetAccountByID(int AccountID)
        {
            var sQuery = @"SELECT AccountID, AccountName, Balance, act.AccountTypeID, act.AccountTypeName, BalanceLimit, c.CategoryID, c.Category, PaymentDueDate, InterestRate, PerkPercent
                          FROM [BudgetApp].[dbo].[Accounts] a
                          JOIN [BudgetApp].[dbo].[Categories] c
                          ON a.CategoryID = c.CategoryID
                          JOIN [BudgetApp].[dbo].[AccountType] act
                          ON a.AccountTypeID = act.AccountTypeID
                          WHERE AccountID = @ID";

            return _db.LoadRecord<GetAccount, dynamic>(sQuery, new { ID = AccountID });
        }
        public Task CreateAccount(Account account)
        {
            var sQuery = "InsertAccount";

            if (account.AccountTypeID != 5010 || account.AccountTypeID != 5011)
            {
                account.CategoryID = 18;
            }

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@AccountName", account.AccountName);
            queryParameters.Add("@AccountOpenDate", account.AccountOpenDate);
            queryParameters.Add("@Balance", account.Balance);
            queryParameters.Add("@AccountTypeID", account.AccountTypeID);
            queryParameters.Add("@BalanceLimit", account.BalanceLimit);
            queryParameters.Add("@CategoryID", account.CategoryID);
            queryParameters.Add("@PaymentDueDate", account.PaymentDueDate);
            queryParameters.Add("@InterestRate", account.InterestRate);
            queryParameters.Add("@PerkPercent", account.PerkPercent);

            return _db.ExecuteStoredProc(sQuery, queryParameters);
        }
        public Task DeleteAccount(int AccountID)
        {
            var sQuery = "Delete Account WHERE AccountID = @ID";

            return _db.SaveData(sQuery, new { ID = AccountID });
        }
        public Task UpdateAccount(Account account)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@AccountID", account.AccountID);
            queryParameters.Add("@AccountName", account.AccountName);
            queryParameters.Add("@AccountOpenDate", account.AccountOpenDate);
            queryParameters.Add("@Balance", account.Balance);
            queryParameters.Add("@AccountTypeID", account.AccountTypeID);
            queryParameters.Add("@BalanceLimit", account.BalanceLimit);
            queryParameters.Add("@CategoryID", account.CategoryID);
            queryParameters.Add("@PaymentDueDate", account.PaymentDueDate);
            queryParameters.Add("@InterestRate", account.InterestRate);
            queryParameters.Add("@PerkPercent", account.PerkPercent);

            var sQuery = @"UPDATE [dbo].[Accounts]
               SET [AccountName] = @AccountName
                  ,[AccountOpenDate] = @AccountOpenDate
                  ,[Balance] = @Balance
                  ,[AccountTypeID] = @AccountTypeID
                  ,[BalanceLimit] = @BalanceLimit
                  ,[CategoryID] = @CategoryID
                  ,[PaymentDueDate] = @PaymentDueDate
                  ,[InterestRate] = @InterestRate
                  ,[PerkPercent] = @PerkPercent
                WHERE [AccountID] = @AccountID";

            return _db.SaveData(sQuery, queryParameters);
        }

        public Task<IList<AccountTypeNameCombine>> GetAccountTypeNames()
        {
            var sQuery = @"SELECT a.AccountID, a.AccountName+' | '+atype.AccountTypeName as AccountNameType
                          FROM [BudgetApp].[dbo].[Accounts] a
                          JOIN [BudgetApp].[dbo].[AccountType] atype
                          ON a.AccountTypeID = atype.AccountTypeID";

            return _db.LoadData<AccountTypeNameCombine, dynamic>(sQuery, new { });
        }
    }
}
