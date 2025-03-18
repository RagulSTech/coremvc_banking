using BankingOops.Models;

namespace BankingOops.Services
{
    public interface IBankService
    {
        List<BankAccount> UserList(string accountType);
        List<BankAccount> SearchBankUser(long accountNumber, string accountType);
        bool Withdraw(long AccountNumber, decimal WithdrawAmount);
        bool Deposite(long AccountNumber, string accountType, decimal DepositAmount);
        List<TransactionHistory> GetLastTransactions(long accountNumber, int count = 10);
        List<BankAccount> GetAllAccounts();
    }
}
