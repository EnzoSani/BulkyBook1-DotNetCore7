using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb1.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        [Area("Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
