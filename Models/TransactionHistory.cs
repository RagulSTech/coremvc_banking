using System.ComponentModel.DataAnnotations;

namespace BankingOops.Models
{
    public class TransactionHistory
    {
        [Key]
        public int TransactionId { get; set; }
        public long AccountNumber { get; set; }
        public string TransactionType { get; set; }     
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }

}
