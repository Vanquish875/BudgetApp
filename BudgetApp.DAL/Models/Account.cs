using System;
using System.Collections.Generic;

namespace BudgetApp.DAL.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public DateTime AccountOpenDate { get; set; } = DateTime.Now;
        public decimal Balance { get; set; }
        public int AccountTypeID { get; set; }
        public decimal? BalanceLimit { get; set; }
        public int CategoryID { get; set; }
        public DateTime ? PaymentDueDate { get; set; }
        public decimal InterestRate { get; set; }
        public decimal ? PerkPercent { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
