using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Hubs;
using SignalRSample.Models;
using System.Diagnostics;

namespace SignalRSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DealthyHallowsHub> dealthyHollow;

        public HomeController(ILogger<HomeController> logger, IHubContext<DealthyHallowsHub> dealthyHollow)
        {
            _logger = logger;
            this.dealthyHollow = dealthyHollow;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DealthyHallow(string type)
        {
            if (SD.DealthyHallowRace.ContainsKey(type))
            {
                SD.DealthyHallowRace[type]++;
            }
            await dealthyHollow.Clients.All.SendAsync("updateDealthyHallowCount", SD.DealthyHallowRace[SD.Cloak], SD.DealthyHallowRace[SD.Stone], SD.DealthyHallowRace[SD.Wand]);
            return Accepted();
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