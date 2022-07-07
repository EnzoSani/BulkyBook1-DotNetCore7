using BulkyBook1.DataAccess.IRepository;
using BulkyBook1.Models;
using BulkyBook1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkyBookWeb1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> orderheaders;
            if (User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Employee)) { 
                orderheaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                orderheaders = _unitOfWork.OrderHeader.GetAll(u=>u.ApplicationUserId==claim.Value,includeProperties: "ApplicationUser");
            }

            switch (status)
            {
                case "pending":
                    orderheaders = orderheaders.Where(u => u.PaymentStatus == SD.PaymentStatusDelayedPayment);                         
                    break;
                case "inprocess":
                    orderheaders = orderheaders.Where(u => u.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    orderheaders = orderheaders.Where(u => u.OrderStatus ==SD.StatusShipped);
                    break;
                case "approved":
                    orderheaders = orderheaders.Where(u => u.OrderStatus == SD.StatusApproved);
                    break;
                default:
                    break;
            }

            return Json(new { data = orderheaders });
        }
        #endregion
    }
}
