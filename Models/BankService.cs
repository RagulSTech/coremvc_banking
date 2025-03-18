using BankingOops.Models;
using System.Collections.Generic;
using System.Linq;
//namespace BankingOops.Models
namespace BankingOops.Services
{
    public class BankService :IBankService
    {
        //private static List<BankAccount> _banks = new List<BankAccount>
        //{
        //    new BankAccountDetails(9898979690, "Ragul", 1500,"Savings"),
        //    new BankAccountDetails(9898973423, "Mani", 3500,"Current"),
        //    new BankAccountDetails(2398973223, "Abhi", 6500,"Savings"),
        //};
        //public List<BankAccount> SearchBankUser(long AccountNumber, string AccountType)
        //{
        //    return _banks.Where(b => b.AccountNumber == AccountNumber && b.AccountType == AccountType).ToList();
        //}
        //public bool Withdraw(long accountNumber, double amount)
        //{
        //    var account = _banks.FirstOrDefault(b => b.AccountNumber == accountNumber);
        //    if (account != null)
        //    {
        //        return account.Withdraw(amount);    
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public List<BankAccount> GetAllAccounts()
        //{
        //    return _banks;
        //}

        private readonly BankDbContext _context;
        public BankService(BankDbContext context)
        {
            _context = context; 
        }
        public List<BankAccount> UserList(string accountType)
        {
            if (string.IsNullOrEmpty(accountType) || accountType == "All")
            {
                return _context.BankAccounts.ToList();  
            }
            return _context.BankAccounts
                .Where(a => a.AccountType == accountType).ToList();
        }
        public List<BankAccount> SearchBankUser(long accountNumber, string accountType)
        {
            return _context.BankAccounts
                .Where(a => a.AccountNumber == accountNumber && a.AccountType == accountType)
                .ToList();
        }
        //public bool Withdraw(long accountNumber, decimal amount)
        //{
        //    var account = _context.BankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

        //    if (account != null)
        //    {
        //        decimal remainingBalance = account.InitialAmount - amount;
        //        if (remainingBalance > 0)
        //        {
        //            return false;
        //        }

        //        account.InitialAmount -= amount;
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    return false; 
        //}
        public bool Withdraw(long accountNumber, decimal amount)
        {
            var account = _context.BankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null && account.InitialAmount >= amount)
            {
                decimal newBalance = account.InitialAmount - amount;
                
                account.InitialAmount -= amount;
                _context.TransactionHistories.Add(new TransactionHistory
                {
                    AccountNumber = accountNumber,
                    TransactionType = "Withdraw",
                    Amount = amount,
                    TransactionDate = DateTime.Now
                });

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        //public bool Deposite(long accountNumber, string accountType, decimal DepositAmount)
        //{
        //    var account = _context.BankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber && a.AccountType == accountType);

        //    if (account != null)
        //    {
        //        decimal Amount = account.InitialAmount + DepositAmount;
        //        account.InitialAmount += DepositAmount;
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
        public bool Deposite(long accountNumber, string accountType, decimal DepositAmount)
        {
            var account = _context.BankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber && a.AccountType == accountType);
            if (account != null)
            {
                account.InitialAmount += DepositAmount;
                _context.TransactionHistories.Add(new TransactionHistory
                {
                    AccountNumber = accountNumber,
                    TransactionType = "Deposit",
                    Amount = DepositAmount,
                    TransactionDate = DateTime.Now
                });

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<BankAccount> GetAllAccounts()
        {
            return _context.BankAccounts.ToList();
        }
        public List<TransactionHistory> GetLastTransactions(long accountNumber, int count = 10)
        {
            return _context.TransactionHistories
                           .Where(t => t.AccountNumber == accountNumber)
                           .OrderByDescending(t => t.TransactionDate)
                           .Take(count)
                           .ToList();
        }

    }
}
