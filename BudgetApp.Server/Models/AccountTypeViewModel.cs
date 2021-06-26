using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Server.Models
{
    public class AccountTypeViewModel
    {
        [Display(Name = "Account Type")]
        public int SelectedAccountType { get; set; }
        public string AccountTypes { get; set; }
    }
}
