using BankingOops.Models;
using System.Collections.Generic;
using System.Linq;
//namespace BankingOops.Models
namespace BankingOops.Services
{
    public class BankService :IBankService
    {
        private static List<BankAccount> _banks = new List<BankAccount>
        {
            new BankAccountDetails(9898979690, "Ragul", 1500,"Savings"),
            new BankAccountDetails(9898973423, "Mani", 3500,"Current"),
            new BankAccountDetails(2398973223, "Abhi", 6500,"Savings"),
        };
        public List<BankAccount> SearchBankUser(long AccountNumber, string AccountType)
        {
            return _banks.Where(b => b.AccountNumber == AccountNumber && b.AccountType == AccountType).ToList();
        }
        public bool Withdraw(long accountNumber, double amount)
        {
            var account = _banks.FirstOrDefault(b => b.AccountNumber == accountNumber);
            if (account != null)
            {
                return account.Withdraw(amount);    
            }
            return false;   
        }
        public List<BankAccount> GetAllAccounts()
        {
            return _banks;
        }
    }
}
