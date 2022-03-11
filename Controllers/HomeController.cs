using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ornekproje.Models;

namespace ornekproje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult CevapFormu()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CevapFormu(Cevap KatilimciCevabi)
        {
            Repository.CevapEkle(KatilimciCevabi);
            return View("Tesekkurler", KatilimciCevabi);
        }

        public ViewResult CevaplariListele()
        {
            return View(Repository.Cevaplar.Where(x => x.AspNetBiliyormu == true));

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


