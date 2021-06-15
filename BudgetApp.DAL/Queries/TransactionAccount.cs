using System;

namespace BudgetApp.DAL.Queries
{
    public class TransactionAccount
    {
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string TransactionTypeName { get; set; }
        public int Recurring { get; set; }
        public DateTime ? RecurringDate { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
