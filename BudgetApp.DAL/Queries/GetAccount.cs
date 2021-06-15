using System;

namespace BudgetApp.DAL.Queries
{
    public class GetAccount
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public decimal BalanceLimit { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PerkPercent { get; set; }
    }
}
