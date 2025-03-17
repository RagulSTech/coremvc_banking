using BankingOops.Models;

namespace BankingOops.Services
{
    public interface IBankService
    {
        List<BankAccount> SearchBankUser(long accountNumber, string accountType);
        bool Withdraw(long AccountNumber, double WithdrawAmount);
        List<BankAccount> GetAllAccounts();
    }
}
