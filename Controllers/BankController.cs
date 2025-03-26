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
        public IActionResult AddBankUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchBankUser(long AccountNumber, string AccountType)
        {
            var filterdata = _bankService.SearchBankUser(AccountNumber, AccountType);
            if (filterdata.Count == 0)
            {
                ViewBag.BankUser = "Invalid User!";   
                return View("Index");   
            }

            HttpContext.Session.SetString("AccountNumber", AccountNumber.ToString());

            return View("Index", filterdata);
        }

        [HttpPost]
        public IActionResult Withdraw(long AccountNumber, decimal WithdrawAmount, string AccountType)
        {
            bool BalanceAmount = _bankService.Withdraw(AccountNumber, WithdrawAmount);
            var filterdata = _bankService.SearchBankUser(AccountNumber, AccountType);
            return View("Index", filterdata);
        }
        [HttpPost]
        public IActionResult Deposit(long AccountNumber, string AccountType, decimal DepositAmount)
        {
            bool BalanceAmount = _bankService.Deposite(AccountNumber, AccountType, DepositAmount);
            var filterdata = _bankService.SearchBankUser(AccountNumber, AccountType);
            return View("Index", filterdata);
        }

        public IActionResult Users()
        {
            return View();
        }
        public IActionResult GetUsers(string AccountType)
        {
            var filterdata = _bankService.UserList(AccountType);
            return View("Users",filterdata);
        }
        public IActionResult TransactionHistory()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetTransaction(long accountNumber, int pagelayout)
        {
            var transactions = _bankService.GetLastTransactions(accountNumber, 10);
            ViewBag.pagelayout = pagelayout;
            if (transactions != null)
            {
                return View("TransactionHistory",transactions);
            }
            return View("TransactionHistory");
        }
    }
}
