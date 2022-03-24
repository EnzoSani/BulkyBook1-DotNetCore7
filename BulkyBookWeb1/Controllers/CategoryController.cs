using BulkyBookWeb1.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;    
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();
            return View();
        }
    }
}
