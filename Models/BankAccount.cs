namespace BankingOops.Models
{
    public class BankAccount
    {
        public long AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public double InitialAmount { get; set; }
        public string AccountType { get; set; }

        public BankAccount(long accountNumber, string accountHolder, double initialAmount, string accountType)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            InitialAmount = initialAmount;
            AccountType = accountType;
        }
        public bool Withdraw(double WithdrawAmount)
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
