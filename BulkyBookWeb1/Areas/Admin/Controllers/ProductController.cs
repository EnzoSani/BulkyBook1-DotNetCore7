using BulkyBook1.DataAccess;
using BulkyBook1.DataAccess.IRepository;
using BulkyBook1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;    
        }
        public IActionResult Index()
        {
           IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }
        //Get
        public IActionResult Create()
        {
            
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {   
          
            if (ModelState.IsValid) { 
            _unitOfWork.Product.Add(obj);
            _unitOfWork.save();
                TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var ProductFromDbFirst = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

            if (ProductFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ProductFromDbFirst);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.save();
                TempData["success"] = "Product edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var ProductFromDbFirst = _unitOfWork.Product.GetFirstOrDefault(u=>u.Id==id);
            if (ProductFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ProductFromDbFirst);
        }
        //Post
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
                _unitOfWork.Product.Remove(obj);
            _unitOfWork.save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
            
        }
    }
}
