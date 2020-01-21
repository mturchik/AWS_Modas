using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AWS_Modas.Models;
using AWS_Modas.Models.Repositories;

namespace AWS_Modas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _eventRepo;

        public HomeController(ILogger<HomeController> logger, IEventRepository eventRepo)
        {
            _logger = logger;
            _eventRepo = eventRepo;
        }

        public IActionResult Index() => View(_eventRepo.Events);

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
