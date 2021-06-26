using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Server.Models
{
    public class AccountViewModel
    {
        [Required, MaxLength(100)]
        public string AccountName { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public int AccountTypeID { get; set; }
        public decimal? BalanceLimit { get; set; }
        public int CategoryID { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public decimal InterestRate { get; set; }
        public decimal? PerkPercent { get; set; }
    }
}
