using BankingOops.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankingOops.Services
{
    public class BankDbContext: IdentityDbContext<IdentityUser>
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}
