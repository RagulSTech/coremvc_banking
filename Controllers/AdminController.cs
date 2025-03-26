using Microsoft.AspNetCore.Mvc;

namespace BankingOops.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
