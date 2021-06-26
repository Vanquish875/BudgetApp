using System;

namespace BudgetApp.Server.Models
{
    public class TransactionViewModel
    {
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public int CategoryID { get; set; }
        public int TransactionTypeID { get; set; }
        public bool Recurring { get; set; }
        public DateTime RecurringDate { get; set; }
    }
}
