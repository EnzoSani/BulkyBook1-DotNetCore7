﻿using BulkyBook1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BulkyBook1.DataAccess.Repository;
using BulkyBook1.DataAccess.IRepository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using BulkyBook1.Models.ViewModels;

namespace BulkyBookWeb1.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;   
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");

            return View(productList);
        }
        public IActionResult Details(int id)
        {
            ShoppingCart objCart = new()
            {
                Count = 1,
                Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,CoverType")
            };

            return View(objCart);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}