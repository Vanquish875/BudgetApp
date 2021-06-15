using System;

namespace BudgetApp.DAL.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CategoryID { get; set; }
        public int TransactionTypeID { get; set; }
        public bool Recurring { get; set; }
        public DateTime ? RecurringDate { get; set; }
    }
}
