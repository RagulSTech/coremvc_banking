using Microsoft.AspNetCore.Mvc;
using BankingOops.Models;
using BankingOops.Services;

namespace BankingOops.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService; //Dependency Injection
        }

        public IActionResult Index()
        {
            return View(new List<BankAccount>());
        }
        [HttpPost]
        public IActionResult SearchBankUser(long AccountNumber, string AccountType)
        {
            var filterdata = _bankService.SearchBankUser(AccountNumber, AccountType);
            return View("Index",filterdata); 
        }
        [HttpPost]
        public IActionResult Withdraw(long AccountNumber, double WithdrawAmount)
        {
            bool BalanceAmount = _bankService.Withdraw(AccountNumber, WithdrawAmount);
            return View();
        }
    }
}
