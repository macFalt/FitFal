using FitFal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FitFalMVC.Application.Services;
using FitFalMVC.Domain.Model;

namespace FitFal.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {

            return View();
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
