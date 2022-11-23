using CDP.Models.ViewModels;
using CDP.Models.Enums;
using CDP.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CDP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly AvisoService _avisoService;

        public HomeController(ILogger<HomeController> logger)
        {
            //_avisoService= avisoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var priorityLow = await _avisoService.FindAllAsync();
            
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