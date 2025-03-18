using System.ComponentModel.DataAnnotations;

namespace BankingOops.Models
{
    public class BankAccount
    {
        [Key]
        public long AccountNumber { get; set; }
        [Required]
        public string AccountHolder { get; set; }
        [Required]
        public decimal InitialAmount { get; set; }
        [Required]
        public string AccountType { get; set; }

        public BankAccount(long accountNumber, string accountHolder, decimal initialAmount, string accountType)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            InitialAmount = initialAmount;
            AccountType = accountType;
        }
        public bool Withdraw(decimal WithdrawAmount)
        {
            if (WithdrawAmount > 0 && WithdrawAmount <= InitialAmount)
            {
                InitialAmount -= WithdrawAmount;
                return true;    
            }
            return false;   
        }
    }
}
