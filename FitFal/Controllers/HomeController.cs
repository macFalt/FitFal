using FitFal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FitFalMVC.Application.Services;
using FitFalMVC.Domain.Model;

namespace FitFal.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
/*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
*/
        [HttpGet]
        public IActionResult Index()
        {

            //var model = productService.GetAllProductForList();
            //return View(model);
            return View();
        }
        

/*
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel model)
        {
            var id = productService.AddProduct(model);
            return View();
        }

        public IActionResult ViewProduct(int productId)
        {
            var productModel = productService.GetProductById(customerId);
            return View(productModel);
            
        }
        
*/
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
