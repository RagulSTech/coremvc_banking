using Microsoft.AspNetCore.Mvc;

namespace BankingOops.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
