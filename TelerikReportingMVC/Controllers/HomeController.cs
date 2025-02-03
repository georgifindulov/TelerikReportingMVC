using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TelerikReportingMVC.Models;
using TelerikReportingMVC.ViewModels;

namespace TelerikReportingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int numberOfReportItemsToTake = 100)
        {
            IndexViewModel viewModel = new()
            {
                NumberOfReportItemsToTake = numberOfReportItemsToTake
            };

            return View(viewModel);
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
