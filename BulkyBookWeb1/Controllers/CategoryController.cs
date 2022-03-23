using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb1.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
