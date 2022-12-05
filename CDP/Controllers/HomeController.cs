using CDP.Models.ViewModels;
using CDP.Models.Enums;
using CDP.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CDP.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlantioService _plantioService;
        private readonly TalhoesService _talhoesService;
        private readonly AvisoService _avisoService;

        public HomeController(PlantioService plantioService, TalhoesService talhoesService, AvisoService avisoService)
        {
            _plantioService = plantioService;
            _talhoesService = talhoesService;
            _avisoService = avisoService;
        }

        public async Task<IActionResult> Index()
        {
            var lowPriority = await _avisoService.FindLowPriority();
            ViewBag.lowPriority = lowPriority;
            var normalPriority = await _avisoService.FindByPriority(1);
            ViewBag.normalpriority = normalPriority;
            var highPriority = await _avisoService.FindByPriority(2);
            ViewBag.highPriority = highPriority;
            var concludedPriority = await _avisoService.FindByPriority(3);
            ViewBag.concludedPriority = concludedPriority;
            var plantio = await _plantioService.FindAllByTalhaoAsync();
            ViewBag.plantio = plantio;

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