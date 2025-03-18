using BankingOops.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingOops.Services
{
    public class BankDbContext: DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }
    }
}
