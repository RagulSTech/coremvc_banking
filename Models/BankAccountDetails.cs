namespace BankingOops.Models
{
    public class BankAccountDetails : BankAccount
    {
        public BankAccountDetails(long accountNumber, string accountHolder, double initialAmount,string accountType)
             : base(accountNumber, accountHolder, initialAmount, accountType) { }
    }
}
